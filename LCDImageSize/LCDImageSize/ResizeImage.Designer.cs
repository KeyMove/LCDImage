namespace LCDImageSize
{
    partial class ResizeImage
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
            this.resizemode = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.v1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WValue = new System.Windows.Forms.TextBox();
            this.HValue = new System.Windows.Forms.TextBox();
            this.standwh = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.standwh);
            this.groupBox1.Controls.Add(this.HValue);
            this.groupBox1.Controls.Add(this.WValue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.v1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.resizemode);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "重新调整大小";
            // 
            // resizemode
            // 
            this.resizemode.AutoSize = true;
            this.resizemode.Checked = true;
            this.resizemode.Location = new System.Drawing.Point(21, 20);
            this.resizemode.Name = "resizemode";
            this.resizemode.Size = new System.Drawing.Size(47, 16);
            this.resizemode.TabIndex = 0;
            this.resizemode.TabStop = true;
            this.resizemode.Text = "像素";
            this.resizemode.UseVisualStyleBackColor = true;
            this.resizemode.CheckedChanged += new System.EventHandler(this.resizemode_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(107, 20);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "百分比";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(88, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(151, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // v1
            // 
            this.v1.AutoSize = true;
            this.v1.Location = new System.Drawing.Point(19, 46);
            this.v1.Name = "v1";
            this.v1.Size = new System.Drawing.Size(35, 12);
            this.v1.TabIndex = 1;
            this.v1.Text = "水平:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "垂直:";
            // 
            // WValue
            // 
            this.WValue.Location = new System.Drawing.Point(61, 46);
            this.WValue.Name = "WValue";
            this.WValue.Size = new System.Drawing.Size(100, 21);
            this.WValue.TabIndex = 2;
            this.WValue.TextChanged += new System.EventHandler(this.WValue_TextChanged);
            this.WValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntInput);
            // 
            // HValue
            // 
            this.HValue.Location = new System.Drawing.Point(60, 80);
            this.HValue.Name = "HValue";
            this.HValue.Size = new System.Drawing.Size(100, 21);
            this.HValue.TabIndex = 2;
            this.HValue.TextChanged += new System.EventHandler(this.HValue_TextChanged);
            this.HValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntInput);
            // 
            // standwh
            // 
            this.standwh.AutoSize = true;
            this.standwh.Checked = true;
            this.standwh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.standwh.Location = new System.Drawing.Point(21, 114);
            this.standwh.Name = "standwh";
            this.standwh.Size = new System.Drawing.Size(84, 16);
            this.standwh.TabIndex = 3;
            this.standwh.Text = "保持纵横比";
            this.standwh.UseVisualStyleBackColor = true;
            // 
            // ResizeImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 184);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ResizeImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图片设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox HValue;
        private System.Windows.Forms.TextBox WValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label v1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton resizemode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox standwh;
    }
}