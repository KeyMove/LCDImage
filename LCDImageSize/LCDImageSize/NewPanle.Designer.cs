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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(75, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WidthValue
            // 
            this.WidthValue.Location = new System.Drawing.Point(53, 12);
            this.WidthValue.Name = "WidthValue";
            this.WidthValue.Size = new System.Drawing.Size(76, 21);
            this.WidthValue.TabIndex = 1;
            this.WidthValue.Text = "16";
            this.WidthValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntInput);
            // 
            // HeightValue
            // 
            this.HeightValue.Location = new System.Drawing.Point(53, 39);
            this.HeightValue.Name = "HeightValue";
            this.HeightValue.Size = new System.Drawing.Size(76, 21);
            this.HeightValue.TabIndex = 1;
            this.HeightValue.Text = "16";
            this.HeightValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntInput);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "宽度:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "高度:";
            // 
            // NewPanle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 93);
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
    }
}