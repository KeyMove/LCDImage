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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Showpanel = new System.Windows.Forms.Panel();
            this.TextInput = new System.Windows.Forms.TextBox();
            this.BitmapView = new System.Windows.Forms.PictureBox();
            this.imglist = new System.Windows.Forms.ListBox();
            this.OutPutData = new System.Windows.Forms.TextBox();
            this.dataoutmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存为文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.resizebutton = new System.Windows.Forms.Button();
            this.saveimg = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.zipmode = new System.Windows.Forms.ComboBox();
            this.enablezip = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.LEDOUTBOX = new System.Windows.Forms.PictureBox();
            this.LEDCODETEXT = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.mode8 = new System.Windows.Forms.RadioButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button10 = new System.Windows.Forms.Button();
            this.buildfontlibbutton10 = new System.Windows.Forms.Button();
            this.fontscanmode = new System.Windows.Forms.Button();
            this.fonttestTB = new System.Windows.Forms.TextBox();
            this.fontsizelabel4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fonttypelabel = new System.Windows.Forms.Label();
            this.fontselectBT = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.fontsizeselectCB = new System.Windows.Forms.ComboBox();
            this.fontb0b7CB = new System.Windows.Forms.CheckBox();
            this.fonta1a9CB = new System.Windows.Forms.CheckBox();
            this.fontprepictureBox1 = new System.Windows.Forms.PictureBox();
            this.fontsomtcheckBox3 = new System.Windows.Forms.CheckBox();
            this.Showpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BitmapView)).BeginInit();
            this.dataoutmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grayval)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LEDOUTBOX)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontprepictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Showpanel
            // 
            this.Showpanel.AutoScroll = true;
            this.Showpanel.BackColor = System.Drawing.Color.White;
            this.Showpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Showpanel.Controls.Add(this.TextInput);
            this.Showpanel.Controls.Add(this.BitmapView);
            this.Showpanel.Location = new System.Drawing.Point(0, 0);
            this.Showpanel.Name = "Showpanel";
            this.Showpanel.Size = new System.Drawing.Size(601, 328);
            this.Showpanel.TabIndex = 0;
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
            this.TextInput.TextChanged += new System.EventHandler(this.TextInput_TextChanged);
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
            this.OutPutData.ContextMenuStrip = this.dataoutmenu;
            this.OutPutData.Location = new System.Drawing.Point(1, 347);
            this.OutPutData.Multiline = true;
            this.OutPutData.Name = "OutPutData";
            this.OutPutData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutPutData.Size = new System.Drawing.Size(601, 134);
            this.OutPutData.TabIndex = 2;
            // 
            // dataoutmenu
            // 
            this.dataoutmenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.dataoutmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem,
            this.保存为文件ToolStripMenuItem});
            this.dataoutmenu.Name = "dataoutmenu";
            this.dataoutmenu.Size = new System.Drawing.Size(161, 56);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 保存为文件ToolStripMenuItem
            // 
            this.保存为文件ToolStripMenuItem.Name = "保存为文件ToolStripMenuItem";
            this.保存为文件ToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.保存为文件ToolStripMenuItem.Text = "保存为文件";
            this.保存为文件ToolStripMenuItem.Click += new System.EventHandler(this.保存为文件ToolStripMenuItem_Click);
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
            this.build.Location = new System.Drawing.Point(623, 444);
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
            this.tabControl1.Location = new System.Drawing.Point(623, 3);
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
            this.tabPage1.Controls.Add(this.resizebutton);
            this.tabPage1.Controls.Add(this.saveimg);
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
            // resizebutton
            // 
            this.resizebutton.Location = new System.Drawing.Point(63, 326);
            this.resizebutton.Name = "resizebutton";
            this.resizebutton.Size = new System.Drawing.Size(60, 23);
            this.resizebutton.TabIndex = 6;
            this.resizebutton.Text = "分辨率";
            this.resizebutton.UseVisualStyleBackColor = true;
            this.resizebutton.Click += new System.EventHandler(this.resizebutton_Click);
            // 
            // saveimg
            // 
            this.saveimg.Location = new System.Drawing.Point(63, 297);
            this.saveimg.Name = "saveimg";
            this.saveimg.Size = new System.Drawing.Size(60, 23);
            this.saveimg.TabIndex = 6;
            this.saveimg.Text = "保存";
            this.saveimg.UseVisualStyleBackColor = true;
            this.saveimg.Click += new System.EventHandler(this.saveimg_Click);
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
            this.label2.Location = new System.Drawing.Point(3, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "数据输出:";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(0, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(768, 507);
            this.tabControl2.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.build);
            this.tabPage3.Controls.Add(this.OutPutData);
            this.tabPage3.Controls.Add(this.tabControl1);
            this.tabPage3.Controls.Add(this.Showpanel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(760, 481);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "图片取模";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.checkBox2);
            this.tabPage4.Controls.Add(this.checkBox1);
            this.tabPage4.Controls.Add(this.LEDOUTBOX);
            this.tabPage4.Controls.Add(this.LEDCODETEXT);
            this.tabPage4.Controls.Add(this.radioButton1);
            this.tabPage4.Controls.Add(this.mode8);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(760, 481);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "数码管取模";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(165, 274);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "字节反序";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 275);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "显示取反";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // LEDOUTBOX
            // 
            this.LEDOUTBOX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LEDOUTBOX.Location = new System.Drawing.Point(8, 6);
            this.LEDOUTBOX.Name = "LEDOUTBOX";
            this.LEDOUTBOX.Size = new System.Drawing.Size(240, 240);
            this.LEDOUTBOX.TabIndex = 2;
            this.LEDOUTBOX.TabStop = false;
            // 
            // LEDCODETEXT
            // 
            this.LEDCODETEXT.Location = new System.Drawing.Point(254, 6);
            this.LEDCODETEXT.Multiline = true;
            this.LEDCODETEXT.Name = "LEDCODETEXT";
            this.LEDCODETEXT.Size = new System.Drawing.Size(495, 235);
            this.LEDCODETEXT.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(165, 252);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 16);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "14段数码管";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // mode8
            // 
            this.mode8.AutoSize = true;
            this.mode8.Checked = true;
            this.mode8.Location = new System.Drawing.Point(8, 252);
            this.mode8.Name = "mode8";
            this.mode8.Size = new System.Drawing.Size(77, 16);
            this.mode8.TabIndex = 1;
            this.mode8.TabStop = true;
            this.mode8.Text = "8段数码管";
            this.mode8.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button10);
            this.tabPage5.Controls.Add(this.buildfontlibbutton10);
            this.tabPage5.Controls.Add(this.fontscanmode);
            this.tabPage5.Controls.Add(this.fonttestTB);
            this.tabPage5.Controls.Add(this.fontsizelabel4);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.fonttypelabel);
            this.tabPage5.Controls.Add(this.fontselectBT);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.fontsizeselectCB);
            this.tabPage5.Controls.Add(this.fontsomtcheckBox3);
            this.tabPage5.Controls.Add(this.fontb0b7CB);
            this.tabPage5.Controls.Add(this.fonta1a9CB);
            this.tabPage5.Controls.Add(this.fontprepictureBox1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(760, 481);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "字库生成";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(244, 184);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 8;
            this.button10.Tag = "1";
            this.button10.Text = "生成ASCII";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.buildfontlibbutton10_Click);
            // 
            // buildfontlibbutton10
            // 
            this.buildfontlibbutton10.Location = new System.Drawing.Point(163, 184);
            this.buildfontlibbutton10.Name = "buildfontlibbutton10";
            this.buildfontlibbutton10.Size = new System.Drawing.Size(75, 23);
            this.buildfontlibbutton10.TabIndex = 8;
            this.buildfontlibbutton10.Text = "生成字库";
            this.buildfontlibbutton10.UseVisualStyleBackColor = true;
            this.buildfontlibbutton10.Click += new System.EventHandler(this.buildfontlibbutton10_Click);
            // 
            // fontscanmode
            // 
            this.fontscanmode.Location = new System.Drawing.Point(237, 117);
            this.fontscanmode.Name = "fontscanmode";
            this.fontscanmode.Size = new System.Drawing.Size(68, 23);
            this.fontscanmode.TabIndex = 7;
            this.fontscanmode.Text = "取模方式";
            this.fontscanmode.UseVisualStyleBackColor = true;
            this.fontscanmode.Click += new System.EventHandler(this.editimg_Click);
            // 
            // fonttestTB
            // 
            this.fonttestTB.Location = new System.Drawing.Point(163, 156);
            this.fonttestTB.Name = "fonttestTB";
            this.fonttestTB.Size = new System.Drawing.Size(106, 21);
            this.fonttestTB.TabIndex = 6;
            this.fonttestTB.Text = "啊";
            this.fonttestTB.TextChanged += new System.EventHandler(this.fonttestTB_TextChanged);
            // 
            // fontsizelabel4
            // 
            this.fontsizelabel4.AutoSize = true;
            this.fontsizelabel4.Location = new System.Drawing.Point(203, 106);
            this.fontsizelabel4.Name = "fontsizelabel4";
            this.fontsizelabel4.Size = new System.Drawing.Size(11, 12);
            this.fontsizelabel4.TabIndex = 5;
            this.fontsizelabel4.Text = "9";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(161, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "预览:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "大小:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "字体:";
            // 
            // fonttypelabel
            // 
            this.fonttypelabel.AutoSize = true;
            this.fonttypelabel.Location = new System.Drawing.Point(202, 92);
            this.fonttypelabel.Name = "fonttypelabel";
            this.fonttypelabel.Size = new System.Drawing.Size(29, 12);
            this.fonttypelabel.TabIndex = 5;
            this.fonttypelabel.Text = "宋体";
            // 
            // fontselectBT
            // 
            this.fontselectBT.Location = new System.Drawing.Point(163, 117);
            this.fontselectBT.Name = "fontselectBT";
            this.fontselectBT.Size = new System.Drawing.Size(68, 23);
            this.fontselectBT.TabIndex = 4;
            this.fontselectBT.Text = "选择字体";
            this.fontselectBT.UseVisualStyleBackColor = true;
            this.fontselectBT.Click += new System.EventHandler(this.fontselectBT_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "点阵大小";
            // 
            // fontsizeselectCB
            // 
            this.fontsizeselectCB.FormattingEnabled = true;
            this.fontsizeselectCB.Items.AddRange(new object[] {
            "12",
            "16",
            "24",
            "32",
            "48"});
            this.fontsizeselectCB.Location = new System.Drawing.Point(163, 69);
            this.fontsizeselectCB.Name = "fontsizeselectCB";
            this.fontsizeselectCB.Size = new System.Drawing.Size(78, 20);
            this.fontsizeselectCB.TabIndex = 2;
            this.fontsizeselectCB.Text = "16";
            this.fontsizeselectCB.TextChanged += new System.EventHandler(this.fonttestTB_TextChanged);
            // 
            // fontb0b7CB
            // 
            this.fontb0b7CB.AutoSize = true;
            this.fontb0b7CB.Checked = true;
            this.fontb0b7CB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fontb0b7CB.Location = new System.Drawing.Point(163, 34);
            this.fontb0b7CB.Name = "fontb0b7CB";
            this.fontb0b7CB.Size = new System.Drawing.Size(78, 16);
            this.fontb0b7CB.TabIndex = 1;
            this.fontb0b7CB.Text = "汉字B0-F7";
            this.fontb0b7CB.UseVisualStyleBackColor = true;
            // 
            // fonta1a9CB
            // 
            this.fonta1a9CB.AutoSize = true;
            this.fonta1a9CB.Location = new System.Drawing.Point(163, 12);
            this.fonta1a9CB.Name = "fonta1a9CB";
            this.fonta1a9CB.Size = new System.Drawing.Size(78, 16);
            this.fonta1a9CB.TabIndex = 1;
            this.fonta1a9CB.Text = "符号A1-A9";
            this.fonta1a9CB.UseVisualStyleBackColor = true;
            // 
            // fontprepictureBox1
            // 
            this.fontprepictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fontprepictureBox1.Location = new System.Drawing.Point(8, 12);
            this.fontprepictureBox1.Name = "fontprepictureBox1";
            this.fontprepictureBox1.Size = new System.Drawing.Size(128, 128);
            this.fontprepictureBox1.TabIndex = 0;
            this.fontprepictureBox1.TabStop = false;
            // 
            // fontsomtcheckBox3
            // 
            this.fontsomtcheckBox3.AutoSize = true;
            this.fontsomtcheckBox3.Checked = true;
            this.fontsomtcheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fontsomtcheckBox3.Location = new System.Drawing.Point(247, 73);
            this.fontsomtcheckBox3.Name = "fontsomtcheckBox3";
            this.fontsomtcheckBox3.Size = new System.Drawing.Size(48, 16);
            this.fontsomtcheckBox3.TabIndex = 1;
            this.fontsomtcheckBox3.Text = "平滑";
            this.fontsomtcheckBox3.UseVisualStyleBackColor = true;
            this.fontsomtcheckBox3.CheckedChanged += new System.EventHandler(this.fontsomtcheckBox3_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 509);
            this.Controls.Add(this.tabControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "图片点阵转换";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Showpanel.ResumeLayout(false);
            this.Showpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BitmapView)).EndInit();
            this.dataoutmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grayval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LEDOUTBOX)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontprepictureBox1)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.ContextMenuStrip dataoutmenu;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存为文件ToolStripMenuItem;
        private System.Windows.Forms.Button resizebutton;
        private System.Windows.Forms.Button saveimg;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox LEDCODETEXT;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton mode8;
        private System.Windows.Forms.PictureBox LEDOUTBOX;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.CheckBox fonta1a9CB;
        private System.Windows.Forms.PictureBox fontprepictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox fontsizeselectCB;
        private System.Windows.Forms.CheckBox fontb0b7CB;
        private System.Windows.Forms.Label fonttypelabel;
        private System.Windows.Forms.Button fontselectBT;
        private System.Windows.Forms.Label fontsizelabel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fonttestTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button fontscanmode;
        private System.Windows.Forms.Button buildfontlibbutton10;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.CheckBox fontsomtcheckBox3;
    }
}

