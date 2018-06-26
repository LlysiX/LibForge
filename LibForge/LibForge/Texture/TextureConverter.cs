﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using LibForge.Extensions;

namespace LibForge.Texture
{
  public class TextureConverter
  {
    static int RGB565ToARGB(ushort input)
    {
      return Color.FromArgb(0xFF,
        ((input >> 11) & 0x1F) << 3 | ((input >> 11) & 0x1F) >> 2,
        ((input >> 5) & 0x3F) << 2 | ((input >> 5) & 0x3F) >> 4,
        (input & 0x1F) << 3 | (input & 0x1F) >> 2).ToArgb();
    }
    static ushort ARGBToRGB565(Color input)
    {
      return (ushort)
        ((((input.R * 0x1F / 0xFF) & 0x1F) << 11) |
         (((input.G * 0x3F / 0xFF) & 0x3F) << 5) |
         (((input.B * 0x1F / 0xFF) & 0x1F)));
    }
    // TODO: Decode DXT5 alpha channel
    public static Bitmap ToBitmap(Texture t, int mipmap)
    {
      var m = t.Mipmaps[mipmap];
      var output = new Bitmap(m.Width, m.Height, PixelFormat.Format32bppArgb);
      int[] imageData = new int[m.Width * m.Height];
      if (m.Data.Length == (imageData.Length * 4))
      {
        Buffer.BlockCopy(m.Data, 0, imageData, 0, m.Data.Length);
      }
      else if (m.Data.Length == imageData.Length)
      {
        DecodeDXT(m, imageData, true);
      }
      else if (m.Data.Length == (imageData.Length / 2))
      {
        DecodeDXT(m, imageData, false);
      }
      else
      {
        throw new Exception($"Don't know what to do with this texture (version={t.Version})");
      }
      // Copy data to bitmap
      {
        var data = output.LockBits(new Rectangle(0, 0, m.Width, m.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        System.Runtime.InteropServices.Marshal.Copy(imageData, 0, data.Scan0, imageData.Length);
        output.UnlockBits(data);
      }
      return output;
    }

    private static void DecodeDXT(Texture.Mipmap m, int[] imageData, bool DXT5)
    {
      int[] colors = new int[4];
      using (var s = new MemoryStream(m.Data))
      {
        ushort[] c = new ushort[4];
        byte[] iData = new byte[4];
        for (var y = 0; y < m.Height; y += 4)
          for (var x = 0; x < m.Width; x += 4)
          {
            if (DXT5) s.Seek(8, SeekOrigin.Current);
            ushort c0 = s.ReadUInt16LE();
            ushort c1 = s.ReadUInt16LE();
            colors[0] = RGB565ToARGB(c0);
            colors[1] = RGB565ToARGB(c1);
            var color0 = Color.FromArgb(colors[0]);
            var color1 = Color.FromArgb(colors[1]);
            s.Read(iData, 0, 4);
            if (c0 > c1)
            {
              colors[2] = Color.FromArgb(0xFF,
                (color0.R * 2 + color1.R) / 3,
                (color0.G * 2 + color1.G) / 3,
                (color0.B * 2 + color1.B) / 3).ToArgb();
              colors[3] = Color.FromArgb(0xFF,
                (color0.R + (color1.R * 2)) / 3,
                (color0.G + (color1.G * 2)) / 3,
                (color0.B + (color1.B * 2)) / 3).ToArgb();
            }
            else
            {
              colors[2] = Color.FromArgb(0xFF,
                (color0.R + color1.R) / 2,
                (color0.G + color1.G) / 2,
                (color0.B + color1.B) / 2).ToArgb();
              colors[3] = Color.Black.ToArgb();
            }
            var offset = y * m.Width + x;
            for (var i = 0; i < 4; i++)
            {
              for (var j = 0; j < 4; j++)
              {
                var idx = (iData[i] >> (2 * j)) & 0x3;
                imageData[offset + i * m.Width + j] = colors[idx];
              }
            }
          }
      }
    }

    private static double ColorDist(Color c1, Color c2)
    {
      // According to Wikipedia, these coefficients should produce an OK delta
      return Math.Sqrt(
          2 * Math.Pow(c1.R - c2.R, 2) 
        + 4 * Math.Pow(c1.G - c2.G, 2) 
        + 3 * Math.Pow(c1.B - c2.B, 2));
    }


    private static IEnumerable<Color> EnumerateBlockColors(Bitmap img, int x, int y)
    {
      for (var y0 = 0; y0< 4; y0++)
        for (var x0 = 0; x0< 4; x0++)
          yield return img.GetPixel(x + x0, y + y0);
    }

    private static byte[] EncodeDxt(Image image, int mapLevel, int nominalSize = 256)
    {
      var img = new Bitmap(image, new Size(nominalSize >> mapLevel, nominalSize >> mapLevel));
      var data = new byte[img.Width * img.Height / 2];
      var idx = 0;
      for(var y = 0; y < img.Height; y += 4)
        for (var x = 0; x < img.Width; x += 4)
        {
          // Pick the farthest-apart colors in this block as the endpoints
          int i0 = 0, j0 = 1;
          var blockColors = EnumerateBlockColors(img, x, y).ToArray();
          double highest = 0;
          for (var i = 0; i < 16; i++)
          {
            for(var j = i + 1; j < 16; j++)
            {
              var d = ColorDist(blockColors[i], blockColors[j]);
              if (d >= highest)
              {
                i0 = i;
                j0 = j;
                highest = d;
              }
            }
          }
          var c1 = blockColors[i0];
          var c2 = blockColors[j0];
          var colors = new[]
          {
            c1, c2,
            Color.FromArgb(0xFF,
              (c1.R * 2 + c2.R) / 3,
              (c1.G * 2 + c2.G) / 3,
              (c1.B * 2 + c2.B) / 3),
            Color.FromArgb(0xFF,
              (c1.R + (c2.R * 2)) / 3,
              (c1.G + (c2.G * 2)) / 3,
              (c1.B + (c2.B * 2)) / 3)
          };
          var color0 = ARGBToRGB565(colors[0]);
          var color1 = ARGBToRGB565(colors[1]);
          Color tmp;
          
          if (color0 < color1)
          {
            // swap colors
            color0 ^= color1;
            color1 ^= color0;
            color0 ^= color1;
            tmp = colors[0];
            colors[0] = colors[1];
            colors[1] = tmp;
          }
          if(color0 == color1)
          {
            // The square is uniform, so just tell the later code not to use color3
            colors[3] = Color.Black;
          }
          data[idx++] = (byte)(color0 & 0xFF);
          data[idx++] = (byte)(color0 >> 8);
          data[idx++] = (byte)(color1 & 0xFF);
          data[idx++] = (byte)(color1 >> 8);

          for (var j = 0; j < 4; j++, idx++)
          {
            for (var i = 0; i < 4; i++)
            {
              var pixel = blockColors[i + 4 * j];
              double lowest = double.MaxValue;
              int bestColor = 0;
              for (var k = 0; k < colors.Length; k++)
              {
                var diff = ColorDist(colors[k], pixel);
                if (diff < lowest)
                {
                  lowest = diff;
                  bestColor = k;
                }
              }
              data[idx] |= (byte)(bestColor << (i * 2));
            }
          }
        }
      return data;
    }

    static byte[] HeaderData256x256 = new byte[]
    {
      0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00,
      0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x04, 0x00, 0x00, 0x00,
      0x02, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
    };

    static byte[] FooterData256x256 = new byte[]
    {
      0x00, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x0F, 0xC2, 0x73, 0x3D, 0x1C, 0x99, 0x4B, 0x3D,
      0x05, 0xC1, 0x0D, 0x3E, 0x00, 0x00, 0x80, 0x3F, 0x08, 0x00, 0x00, 0x00
    };

    // TODO: Copy texture data with mipmaps directly instead of re-encoding
    public static Texture MiloPngToTexture(Stream s)
    {
      if (s.ReadUInt24BE() != 0x010818) throw new ArgumentException("Stream was not a supported png_xbox");
      s.Position += 4;
      var width = s.ReadInt16LE();
      var height = s.ReadInt16LE();
      s.Position = 32;
      var m = new Texture.Mipmap
      {
        Width = width,
        Height = height,
        Data = s.ReadBytes(width * height)
      };
      for (var i = 0; i < m.Data.Length; i += 2)
      {
        var tmp = m.Data[i];
        m.Data[i] = m.Data[i + 1];
        m.Data[i + 1] = tmp;
      }
      Console.WriteLine($"Dimensions: {width}x{height}");
      var output = new Bitmap(m.Width, m.Height, PixelFormat.Format32bppArgb);
      int[] imageData = new int[m.Width * m.Height];
      DecodeDXT(m, imageData, true);
      var data = output.LockBits(new Rectangle(0, 0, m.Width, m.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
      System.Runtime.InteropServices.Marshal.Copy(imageData, 0, data.Scan0, imageData.Length);
      output.UnlockBits(data);
      return ToTexture(output);
    }

    public static Texture ToTexture(Image image)
    {
      Texture.Mipmap[] maps = new Texture.Mipmap[7];
      for(var i = 0; i < maps.Length; i++)
      {
        maps[i] = new Texture.Mipmap
        {
          Width = 256 / (1 << i),
          Height = 256 / (1 << i),
          Data = EncodeDxt(image, i)
        };
      }
      return new Texture
      {
        HeaderData = HeaderData256x256,
        FooterData = FooterData256x256,
        Version = 6,
        Mipmaps = maps
      };
    }
  }
}
