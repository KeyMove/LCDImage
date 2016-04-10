namespace LCDImageSize
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Showpanel = new System.Windows.Forms.Panel();
            this.BitmapView = new System.Windows.Forms.PictureBox();
            this.imglist = new System.Windows.Forms.ListBox();
            this.OutPutData = new System.Windows.Forms.TextBox();
            this.addimg = new System.Windows.Forms.Button();
            this.grayval = new System.Windows.Forms.TrackBar();
            this.rmimg = new System.Windows.Forms.Button();
            this.editimg = new System.Windows.Forms.Button();
            this.build = new System.Windows.Forms.Button();
            this.newimage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.zipmode = new System.Windows.Forms.ComboBox();
            this.enablezip = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextInput = new System.Windows.Forms.TextBox();
            this.Showpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BitmapView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grayval)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Showpanel
            // 
            this.Showpanel.AutoScroll = true;
            this.Showpanel.BackColor = System.Drawing.Color.White;
            this.Showpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Showpanel.Controls.Add(this.TextInput);
            this.Showpanel.Controls.Add(this.BitmapView);
            this.Showpanel.Location = new System.Drawing.Point(12, 12);
            this.Showpanel.Name = "Showpanel";
            this.Showpanel.Size = new System.Drawing.Size(601, 328);
            this.Showpanel.TabIndex = 0;
            // 
            // BitmapView
            // 
            this.BitmapView.Location = new System.Drawing.Point(0, 0);
            this.BitmapView.Name = "BitmapView";
            this.BitmapView.Size = new System.Drawing.Size(598, 325);
            this.BitmapView.TabIndex = 0;
            this.BitmapView.TabStop = false;
            this.BitmapView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BitmapView_MouseClick);
            this.BitmapView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BitmapView_MouseDown);
            this.BitmapView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BitmapView_MouseMove);
            this.BitmapView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BitmapView_MouseUp);
            // 
            // imglist
            // 
            this.imglist.FormattingEnabled = true;
            this.imglist.HorizontalScrollbar = true;
            this.imglist.ItemHeight = 12;
            this.imglist.Location = new System.Drawing.Point(0, 0);
            this.imglist.Name = "imglist";
            this.imglist.Size = new System.Drawing.Size(126, 256);
            this.imglist.TabIndex = 1;
            this.imglist.SelectedIndexChanged += new System.EventHandler(this.imglist_SelectedIndexChanged);
            // 
            // OutPutData
            // 
            this.OutPutData.Location = new System.Drawing.Point(12, 355);
            this.OutPutData.Multiline = true;
            this.OutPutData.Name = "OutPutData";
            this.OutPutData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutPutData.Size = new System.Drawing.Size(601, 134);
            this.OutPutData.TabIndex = 2;
            // 
            // addimg
            // 
            this.addimg.Location = new System.Drawing.Point(0, 268);
            this.addimg.Name = "addimg";
            this.addimg.Size = new System.Drawing.Size(60, 23);
            this.addimg.TabIndex = 3;
            this.addimg.Text = "添加";
            this.addimg.UseVisualStyleBackColor = true;
            this.addimg.Click += new System.EventHandler(this.addimg_Click);
            // 
            // grayval
            // 
            this.grayval.BackColor = System.Drawing.Color.White;
            this.grayval.Location = new System.Drawing.Point(0, 369);
            this.grayval.Maximum = 100;
            this.grayval.Name = "grayval";
            this.grayval.Size = new System.Drawing.Size(126, 45);
            this.grayval.TabIndex = 4;
            this.grayval.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.grayval.Value = 50;
            this.grayval.Scroll += new System.EventHandler(this.grayval_Scroll);
            // 
            // rmimg
            // 
            this.rmimg.Location = new System.Drawing.Point(63, 268);
            this.rmimg.Name = "rmimg";
            this.rmimg.Size = new System.Drawing.Size(60, 23);
            this.rmimg.TabIndex = 3;
            this.rmimg.Text = "删除";
            this.rmimg.UseVisualStyleBackColor = true;
            this.rmimg.Click += new System.EventHandler(this.rmimg_Click);
            // 
            // editimg
            // 
            this.editimg.Location = new System.Drawing.Point(0, 326);
            this.editimg.Name = "editimg";
            this.editimg.Size = new System.Drawing.Size(60, 23);
            this.editimg.TabIndex = 5;
            this.editimg.Text = "设置";
            this.editimg.UseVisualStyleBackColor = true;
            this.editimg.Click += new System.EventHandler(this.editimg_Click);
            // 
            // build
            // 
            this.build.Location = new System.Drawing.Point(614, 458);
            this.build.Name = "build";
            this.build.Size = new System.Drawing.Size(134, 31);
            this.build.TabIndex = 5;
            this.build.Text = "生成";
            this.build.UseVisualStyleBackColor = true;
            this.build.Click += new System.EventHandler(this.build_Click);
            // 
            // newimage
            // 
            this.newimage.Location = new System.Drawing.Point(0, 297);
            this.newimage.Name = "newimage";
            this.newimage.Size = new System.Drawing.Size(60, 23);
            this.newimage.TabIndex = 6;
            this.newimage.Text = "新建";
            this.newimage.UseVisualStyleBackColor = true;
            this.newimage.Click += new System.EventHandler(this.newimage_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "↑";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(50, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "R";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(50, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "↓";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(21, 45);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(23, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "←";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(79, 45);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(23, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "→";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("宋体", 12F);
            this.button6.Location = new System.Drawing.Point(79, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(23, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "↺";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("宋体", 12F);
            this.button7.Location = new System.Drawing.Point(21, 16);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(23, 23);
            this.button7.TabIndex = 12;
            this.button7.Text = "↻";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("宋体", 12F);
            this.button8.Location = new System.Drawing.Point(21, 74);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(23, 23);
            this.button8.TabIndex = 12;
            this.button8.Text = "⇄";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("宋体", 12F);
            this.button9.Location = new System.Drawing.Point(79, 74);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(23, 23);
            this.button9.TabIndex = 12;
            this.button9.Text = "⇅";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 107);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像操作";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(614, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(134, 440);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.imglist);
            this.tabPage1.Controls.Add(this.addimg);
            this.tabPage1.Controls.Add(this.newimage);
            this.tabPage1.Controls.Add(this.rmimg);
            this.tabPage1.Controls.Add(this.grayval);
            this.tabPage1.Controls.Add(this.editimg);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(126, 414);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "图像列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "图像阈值";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(126, 414);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "图像设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.zipmode);
            this.groupBox2.Controls.Add(this.enablezip);
            this.groupBox2.Location = new System.Drawing.Point(3, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 72);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图像压缩";
            // 
            // zipmode
            // 
            this.zipmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zipmode.Enabled = false;
            this.zipmode.FormattingEnabled = true;
            this.zipmode.Items.AddRange(new object[] {
            "压缩算法1"});
            this.zipmode.Location = new System.Drawing.Point(4, 43);
            this.zipmode.Name = "zipmode";
            this.zipmode.Size = new System.Drawing.Size(110, 20);
            this.zipmode.TabIndex = 1;
            // 
            // enablezip
            // 
            this.enablezip.AutoSize = true;
            this.enablezip.Location = new System.Drawing.Point(6, 20);
            this.enablezip.Name = "enablezip";
            this.enablezip.Size = new System.Drawing.Size(72, 16);
            this.enablezip.TabIndex = 0;
            this.enablezip.Text = "使用压缩";
            this.enablezip.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "数据输出:";
            // 
            // TextInput
            // 
            this.TextInput.Font = new System.Drawing.Font("宋体", 16F);
            this.TextInput.Location = new System.Drawing.Point(3, 272);
            this.TextInput.Multiline = true;
            this.TextInput.Name = "TextInput";
            this.TextInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextInput.Size = new System.Drawing.Size(592, 51);
            this.TextInput.TabIndex = 1;
            this.TextInput.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 491);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.build);
            this.Controls.Add(this.OutPutData);
            this.Controls.Add(this.Showpanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Showpanel.ResumeLayout(false);
            this.Showpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BitmapView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grayval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Showpanel;
        private System.Windows.Forms.PictureBox BitmapView;
        private System.Windows.Forms.ListBox imglist;
        private System.Windows.Forms.TextBox OutPutData;
        private System.Windows.Forms.Button addimg;
        private System.Windows.Forms.TrackBar grayval;
        private System.Windows.Forms.Button rmimg;
        private System.Windows.Forms.Button editimg;
        private System.Windows.Forms.Button build;
        private System.Windows.Forms.Button newimage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox zipmode;
        private System.Windows.Forms.CheckBox enablezip;
        private System.Windows.Forms.TextBox TextInput;
    }
}

