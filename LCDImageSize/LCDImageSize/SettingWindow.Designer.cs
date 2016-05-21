namespace LCDImageSize
{
    partial class SettingWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rc1 = new System.Windows.Forms.RadioButton();
            this.rc2 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rv2 = new System.Windows.Forms.RadioButton();
            this.rv1 = new System.Windows.Forms.RadioButton();
            this.selectmode = new System.Windows.Forms.ComboBox();
            this.codemode = new System.Windows.Forms.TextBox();
            this.DataFormatBox = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.showdemo = new System.Windows.Forms.PictureBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.ImageSizeBox = new System.Windows.Forms.GroupBox();
            this.WValue = new System.Windows.Forms.TextBox();
            this.HValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.DataFormatBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showdemo)).BeginInit();
            this.ImageSizeBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rc1);
            this.groupBox1.Controls.Add(this.rc2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(72, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "点阵格式";
            // 
            // rc1
            // 
            this.rc1.AutoSize = true;
            this.rc1.Checked = true;
            this.rc1.Location = new System.Drawing.Point(6, 20);
            this.rc1.Name = "rc1";
            this.rc1.Size = new System.Drawing.Size(47, 16);
            this.rc1.TabIndex = 2;
            this.rc1.TabStop = true;
            this.rc1.Text = "黑点";
            this.rc1.UseVisualStyleBackColor = true;
            // 
            // rc2
            // 
            this.rc2.AutoSize = true;
            this.rc2.Location = new System.Drawing.Point(6, 42);
            this.rc2.Name = "rc2";
            this.rc2.Size = new System.Drawing.Size(47, 16);
            this.rc2.TabIndex = 3;
            this.rc2.Text = "白点";
            this.rc2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rv2);
            this.groupBox2.Controls.Add(this.rv1);
            this.groupBox2.Controls.Add(this.selectmode);
            this.groupBox2.Location = new System.Drawing.Point(90, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(103, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "取模方式";
            // 
            // rv2
            // 
            this.rv2.AutoSize = true;
            this.rv2.Location = new System.Drawing.Point(50, 42);
            this.rv2.Name = "rv2";
            this.rv2.Size = new System.Drawing.Size(47, 16);
            this.rv2.TabIndex = 6;
            this.rv2.Text = "反序";
            this.rv2.UseVisualStyleBackColor = true;
            this.rv2.CheckedChanged += new System.EventHandler(this.updateselect);
            // 
            // rv1
            // 
            this.rv1.AutoSize = true;
            this.rv1.Checked = true;
            this.rv1.Location = new System.Drawing.Point(6, 42);
            this.rv1.Name = "rv1";
            this.rv1.Size = new System.Drawing.Size(47, 16);
            this.rv1.TabIndex = 5;
            this.rv1.TabStop = true;
            this.rv1.Text = "正序";
            this.rv1.UseVisualStyleBackColor = true;
            this.rv1.CheckedChanged += new System.EventHandler(this.updateselect);
            // 
            // selectmode
            // 
            this.selectmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectmode.FormattingEnabled = true;
            this.selectmode.Items.AddRange(new object[] {
            "列行式",
            "行列式",
            "逐列式",
            "逐行式"});
            this.selectmode.Location = new System.Drawing.Point(6, 16);
            this.selectmode.Name = "selectmode";
            this.selectmode.Size = new System.Drawing.Size(90, 20);
            this.selectmode.TabIndex = 4;
            this.selectmode.SelectedIndexChanged += new System.EventHandler(this.updateselect2);
            // 
            // codemode
            // 
            this.codemode.Location = new System.Drawing.Point(7, 20);
            this.codemode.Name = "codemode";
            this.codemode.Size = new System.Drawing.Size(168, 21);
            this.codemode.TabIndex = 7;
            this.codemode.Text = "0x{0:X2},";
            // 
            // DataFormatBox
            // 
            this.DataFormatBox.Controls.Add(this.codemode);
            this.DataFormatBox.Location = new System.Drawing.Point(12, 83);
            this.DataFormatBox.Name = "DataFormatBox";
            this.DataFormatBox.Size = new System.Drawing.Size(181, 50);
            this.DataFormatBox.TabIndex = 2;
            this.DataFormatBox.TabStop = false;
            this.DataFormatBox.Text = "数据格式";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.showdemo);
            this.groupBox4.Location = new System.Drawing.Point(12, 139);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(100, 100);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "取模演示";
            // 
            // showdemo
            // 
            this.showdemo.Location = new System.Drawing.Point(10, 13);
            this.showdemo.Name = "showdemo";
            this.showdemo.Size = new System.Drawing.Size(81, 81);
            this.showdemo.TabIndex = 0;
            this.showdemo.TabStop = false;
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(118, 216);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "确定";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ImageSizeBox
            // 
            this.ImageSizeBox.Controls.Add(this.label2);
            this.ImageSizeBox.Controls.Add(this.label1);
            this.ImageSizeBox.Controls.Add(this.HValue);
            this.ImageSizeBox.Controls.Add(this.WValue);
            this.ImageSizeBox.Location = new System.Drawing.Point(117, 139);
            this.ImageSizeBox.Name = "ImageSizeBox";
            this.ImageSizeBox.Size = new System.Drawing.Size(76, 71);
            this.ImageSizeBox.TabIndex = 5;
            this.ImageSizeBox.TabStop = false;
            this.ImageSizeBox.Text = "图像尺寸";
            this.ImageSizeBox.Visible = false;
            // 
            // WValue
            // 
            this.WValue.Location = new System.Drawing.Point(28, 20);
            this.WValue.Name = "WValue";
            this.WValue.Size = new System.Drawing.Size(46, 21);
            this.WValue.TabIndex = 0;
            this.WValue.Text = "0";
            this.WValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntInput);
            // 
            // HValue
            // 
            this.HValue.Location = new System.Drawing.Point(28, 43);
            this.HValue.Name = "HValue";
            this.HValue.Size = new System.Drawing.Size(46, 21);
            this.HValue.TabIndex = 1;
            this.HValue.Text = "0";
            this.HValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntInput);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "宽";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "高";
            // 
            // SettingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 247);
            this.Controls.Add(this.ImageSizeBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.DataFormatBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.DataFormatBox.ResumeLayout(false);
            this.DataFormatBox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showdemo)).EndInit();
            this.ImageSizeBox.ResumeLayout(false);
            this.ImageSizeBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rc1;
        private System.Windows.Forms.RadioButton rc2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rv2;
        private System.Windows.Forms.RadioButton rv1;
        private System.Windows.Forms.ComboBox selectmode;
        private System.Windows.Forms.TextBox codemode;
        private System.Windows.Forms.GroupBox DataFormatBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox showdemo;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.GroupBox ImageSizeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HValue;
        private System.Windows.Forms.TextBox WValue;
    }
}