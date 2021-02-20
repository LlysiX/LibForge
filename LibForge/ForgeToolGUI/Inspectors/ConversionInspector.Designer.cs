﻿namespace ForgeToolGUI.Inspectors
{
  partial class ConversionInspector
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.pickFileButton = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.selectedFileLabel = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.volumeAdjustCheckBox = new System.Windows.Forms.CheckBox();
      this.euCheckBox = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.descriptionBox = new System.Windows.Forms.TextBox();
      this.idBox = new System.Windows.Forms.TextBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.label5 = new System.Windows.Forms.Label();
      this.logBox = new System.Windows.Forms.TextBox();
      this.buildButton = new System.Windows.Forms.Button();
      this.contentIdTextBox = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // pickFileButton
      // 
      this.pickFileButton.Location = new System.Drawing.Point(9, 29);
      this.pickFileButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.pickFileButton.Name = "pickFileButton";
      this.pickFileButton.Size = new System.Drawing.Size(112, 35);
      this.pickFileButton.TabIndex = 0;
      this.pickFileButton.Text = "Pick a File";
      this.pickFileButton.UseVisualStyleBackColor = true;
      this.pickFileButton.Click += new System.EventHandler(this.pickFileButton_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.selectedFileLabel);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.pickFileButton);
      this.groupBox1.Location = new System.Drawing.Point(6, 5);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.groupBox1.Size = new System.Drawing.Size(710, 106);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Step 1: Pick a CON";
      // 
      // selectedFileLabel
      // 
      this.selectedFileLabel.AutoSize = true;
      this.selectedFileLabel.Location = new System.Drawing.Point(124, 69);
      this.selectedFileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.selectedFileLabel.Name = "selectedFileLabel";
      this.selectedFileLabel.Size = new System.Drawing.Size(0, 20);
      this.selectedFileLabel.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 69);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(105, 20);
      this.label1.TabIndex = 1;
      this.label1.Text = "Selected File:";
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.volumeAdjustCheckBox);
      this.groupBox2.Controls.Add(this.euCheckBox);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.descriptionBox);
      this.groupBox2.Controls.Add(this.idBox);
      this.groupBox2.Enabled = false;
      this.groupBox2.Location = new System.Drawing.Point(6, 122);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.groupBox2.Size = new System.Drawing.Size(710, 166);
      this.groupBox2.TabIndex = 2;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Step 2: Choose Options";
      // 
      // volumeAdjustCheckBox
      // 
      this.volumeAdjustCheckBox.AutoSize = true;
      this.volumeAdjustCheckBox.Checked = true;
      this.volumeAdjustCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.volumeAdjustCheckBox.Location = new System.Drawing.Point(290, 134);
      this.volumeAdjustCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.volumeAdjustCheckBox.Name = "volumeAdjustCheckBox";
      this.volumeAdjustCheckBox.Size = new System.Drawing.Size(218, 24);
      this.volumeAdjustCheckBox.TabIndex = 6;
      this.volumeAdjustCheckBox.Text = "Adjust audio mix for RB4?";
      this.volumeAdjustCheckBox.UseVisualStyleBackColor = true;
      // 
      // euCheckBox
      // 
      this.euCheckBox.AutoSize = true;
      this.euCheckBox.Location = new System.Drawing.Point(129, 134);
      this.euCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.euCheckBox.Name = "euCheckBox";
      this.euCheckBox.Size = new System.Drawing.Size(150, 24);
      this.euCheckBox.TabIndex = 5;
      this.euCheckBox.Text = "Build for SCEE?";
      this.euCheckBox.UseVisualStyleBackColor = true;
      this.euCheckBox.CheckedChanged += new System.EventHandler(this.euCheckBox_CheckedChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(32, 74);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(93, 20);
      this.label3.TabIndex = 4;
      this.label3.Text = "Description:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(14, 34);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(105, 20);
      this.label2.TabIndex = 3;
      this.label2.Text = "ID (16 chars):";
      // 
      // descriptionBox
      // 
      this.descriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.descriptionBox.Location = new System.Drawing.Point(129, 69);
      this.descriptionBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.descriptionBox.Multiline = true;
      this.descriptionBox.Name = "descriptionBox";
      this.descriptionBox.Size = new System.Drawing.Size(570, 53);
      this.descriptionBox.TabIndex = 2;
      // 
      // idBox
      // 
      this.idBox.Location = new System.Drawing.Point(129, 29);
      this.idBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.idBox.Name = "idBox";
      this.idBox.Size = new System.Drawing.Size(241, 26);
      this.idBox.TabIndex = 0;
      this.idBox.TextChanged += new System.EventHandler(this.idBox_TextChanged);
      // 
      // groupBox3
      // 
      this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox3.Controls.Add(this.label5);
      this.groupBox3.Controls.Add(this.logBox);
      this.groupBox3.Controls.Add(this.buildButton);
      this.groupBox3.Controls.Add(this.contentIdTextBox);
      this.groupBox3.Controls.Add(this.label4);
      this.groupBox3.Enabled = false;
      this.groupBox3.Location = new System.Drawing.Point(6, 297);
      this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.groupBox3.Size = new System.Drawing.Size(710, 323);
      this.groupBox3.TabIndex = 3;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Step 3: Build PKG";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(9, 71);
      this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(40, 20);
      this.label5.TabIndex = 4;
      this.label5.Text = "Log:";
      // 
      // logBox
      // 
      this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.logBox.Location = new System.Drawing.Point(9, 95);
      this.logBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.logBox.Multiline = true;
      this.logBox.Name = "logBox";
      this.logBox.ReadOnly = true;
      this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.logBox.Size = new System.Drawing.Size(690, 216);
      this.logBox.TabIndex = 3;
      // 
      // buildButton
      // 
      this.buildButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buildButton.Location = new System.Drawing.Point(588, 17);
      this.buildButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.buildButton.Name = "buildButton";
      this.buildButton.Size = new System.Drawing.Size(112, 35);
      this.buildButton.TabIndex = 2;
      this.buildButton.Text = "Build";
      this.buildButton.UseVisualStyleBackColor = true;
      this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
      // 
      // contentIdTextBox
      // 
      this.contentIdTextBox.AutoSize = true;
      this.contentIdTextBox.Location = new System.Drawing.Point(147, 25);
      this.contentIdTextBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.contentIdTextBox.Name = "contentIdTextBox";
      this.contentIdTextBox.Size = new System.Drawing.Size(0, 20);
      this.contentIdTextBox.TabIndex = 1;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(9, 25);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(128, 20);
      this.label4.TabIndex = 0;
      this.label4.Text = "PKG Content ID:";
      // 
      // ConversionInspector
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "ConversionInspector";
      this.Size = new System.Drawing.Size(720, 625);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button pickFileButton;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label selectedFileLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.TextBox idBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox descriptionBox;
    private System.Windows.Forms.CheckBox euCheckBox;
    private System.Windows.Forms.Label contentIdTextBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox logBox;
    private System.Windows.Forms.Button buildButton;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.CheckBox volumeAdjustCheckBox;
  }
}
