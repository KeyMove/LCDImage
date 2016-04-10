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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.showdemo = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showdemo)).BeginInit();
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
            this.rc1.TabIndex = 0;
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
            this.rc2.TabIndex = 0;
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
            this.rv2.TabIndex = 1;
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
            this.rv1.TabIndex = 1;
            this.rv1.TabStop = true;
            this.rv1.Text = "正序";
            this.rv1.UseVisualStyleBackColor = true;
            this.rv1.CheckedChanged += new System.EventHandler(this.updateselect);
            // 
            // selectmode
            // 
            this.selectmode.FormattingEnabled = true;
            this.selectmode.Items.AddRange(new object[] {
            "列行式",
            "行列式",
            "逐列式",
            "逐行式"});
            this.selectmode.Location = new System.Drawing.Point(6, 16);
            this.selectmode.Name = "selectmode";
            this.selectmode.Size = new System.Drawing.Size(90, 20);
            this.selectmode.TabIndex = 0;
            this.selectmode.SelectedIndexChanged += new System.EventHandler(this.updateselect2);
            // 
            // codemode
            // 
            this.codemode.Location = new System.Drawing.Point(7, 20);
            this.codemode.Name = "codemode";
            this.codemode.Size = new System.Drawing.Size(168, 21);
            this.codemode.TabIndex = 2;
            this.codemode.Text = "0x{0:X2},";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.codemode);
            this.groupBox3.Location = new System.Drawing.Point(12, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 50);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据格式";
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
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(118, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SettingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 247);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showdemo)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox showdemo;
        private System.Windows.Forms.Button button1;
    }
}