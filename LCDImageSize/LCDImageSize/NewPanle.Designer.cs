namespace LCDImageSize
{
    partial class NewPanle
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
            this.button1 = new System.Windows.Forms.Button();
            this.WidthValue = new System.Windows.Forms.TextBox();
            this.HeightValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textselectradioButton1 = new System.Windows.Forms.RadioButton();
            this.picselectradioButton2 = new System.Windows.Forms.RadioButton();
            this.TextValue = new System.Windows.Forms.TextBox();
            this.textsizecomboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(126, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WidthValue
            // 
            this.WidthValue.Location = new System.Drawing.Point(56, 30);
            this.WidthValue.Name = "WidthValue";
            this.WidthValue.Size = new System.Drawing.Size(76, 21);
            this.WidthValue.TabIndex = 1;
            this.WidthValue.Text = "16";
            this.WidthValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntInput);
            // 
            // HeightValue
            // 
            this.HeightValue.Location = new System.Drawing.Point(56, 57);
            this.HeightValue.Name = "HeightValue";
            this.HeightValue.Size = new System.Drawing.Size(76, 21);
            this.HeightValue.TabIndex = 1;
            this.HeightValue.Text = "16";
            this.HeightValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntInput);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "宽度:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "高度:";
            // 
            // textselectradioButton1
            // 
            this.textselectradioButton1.AutoSize = true;
            this.textselectradioButton1.Location = new System.Drawing.Point(12, 84);
            this.textselectradioButton1.Name = "textselectradioButton1";
            this.textselectradioButton1.Size = new System.Drawing.Size(47, 16);
            this.textselectradioButton1.TabIndex = 4;
            this.textselectradioButton1.Text = "文字";
            this.textselectradioButton1.UseVisualStyleBackColor = true;
            this.textselectradioButton1.CheckedChanged += new System.EventHandler(this.textselectradioButton1_CheckedChanged);
            // 
            // picselectradioButton2
            // 
            this.picselectradioButton2.AutoSize = true;
            this.picselectradioButton2.Checked = true;
            this.picselectradioButton2.Location = new System.Drawing.Point(12, 12);
            this.picselectradioButton2.Name = "picselectradioButton2";
            this.picselectradioButton2.Size = new System.Drawing.Size(47, 16);
            this.picselectradioButton2.TabIndex = 4;
            this.picselectradioButton2.TabStop = true;
            this.picselectradioButton2.Text = "图片";
            this.picselectradioButton2.UseVisualStyleBackColor = true;
            this.picselectradioButton2.CheckedChanged += new System.EventHandler(this.textselectradioButton1_CheckedChanged);
            // 
            // TextValue
            // 
            this.TextValue.Enabled = false;
            this.TextValue.Location = new System.Drawing.Point(12, 106);
            this.TextValue.Multiline = true;
            this.TextValue.Name = "TextValue";
            this.TextValue.Size = new System.Drawing.Size(189, 21);
            this.TextValue.TabIndex = 5;
            // 
            // textsizecomboBox1
            // 
            this.textsizecomboBox1.Enabled = false;
            this.textsizecomboBox1.FormattingEnabled = true;
            this.textsizecomboBox1.Items.AddRange(new object[] {
            "12",
            "16",
            "24",
            "32",
            "48"});
            this.textsizecomboBox1.Location = new System.Drawing.Point(12, 134);
            this.textsizecomboBox1.Name = "textsizecomboBox1";
            this.textsizecomboBox1.Size = new System.Drawing.Size(60, 20);
            this.textsizecomboBox1.TabIndex = 6;
            this.textsizecomboBox1.Text = "16";
            // 
            // NewPanle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 167);
            this.Controls.Add(this.textsizecomboBox1);
            this.Controls.Add(this.TextValue);
            this.Controls.Add(this.picselectradioButton2);
            this.Controls.Add(this.textselectradioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HeightValue);
            this.Controls.Add(this.WidthValue);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewPanle";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建图片";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox WidthValue;
        private System.Windows.Forms.TextBox HeightValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton textselectradioButton1;
        private System.Windows.Forms.RadioButton picselectradioButton2;
        private System.Windows.Forms.TextBox TextValue;
        private System.Windows.Forms.ComboBox textsizecomboBox1;
    }
}