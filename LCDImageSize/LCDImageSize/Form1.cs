using PIDHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCDImageSize
{
    public partial class Form1 : Form
    {
        byte[] RV = new byte[256];
        byte[] GV = new byte[256];
        byte[] BV = new byte[256];

        byte[] data;
        COMHelper COM;
        public Form1()
        {
            InitializeComponent();
            InitRGB();
            BitmapView.MouseWheel += BitmapView_MouseWheel;
            BitStream bs = new BitStream(new byte[10]);
            bs.Writebit(false);
            //bs.Writebits(0x3A, 6);
            bs.WriteByte(0xff);
            bs.Writebit(true);
            BitStream br = new BitStream(bs.toBytes());
            //br.ReadBit();
            int bdata = br.ReadBits(10);
            //bdata = br.ReadBits(3);
            fontmap = new Bitmap(128, 128);
            fontdraw = Graphics.FromImage(fontmap);
            fontdraw.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

            modmap = new Bitmap(128, 128);
            moddraw = Graphics.FromImage(modmap);
            moddraw.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            selectfont = Font;
            fonttestTB_TextChanged(null, null);

            easydrag.setDrag = LayerImageView;
            newLayer.Icon = Icon;
            newLayer.StartPosition = FormStartPosition.CenterParent;


            COM = new COMHelper(groupBox3, tb_uartrx, null);
            List<TextBox> textlist = new List<TextBox>();
            
            for(int i = 0; i < 16; i++)
            {
                CheckBox cb = new CheckBox() { AutoSize = true, Text = "", Location = new Point(uart_tp_check.Left, uart_tp_check.Top + i * 25) };
                TextBox tb = new TextBox() { Tag = cb, Location = new Point(uart_tp_text.Left, uart_tp_text.Top + i * 25), Size = uart_tp_text.Size };
                Button bt = new Button() { Tag = tb, Text = "" + i, Location = new Point(uart_tp_send.Left, uart_tp_send.Top + i * 25), Size = uart_tp_send.Size };
                bt.Click += (s, e) => { 
                    TextBox t=bt.Tag as TextBox;
                    if((t.Tag as CheckBox).Checked)
                    {
                        List<byte> list = new List<byte>();
                        foreach(var v in t.Text.Split(' '))
                        {
                            if (v.Length < 2) continue;
                            var vv = v.ToUpper().Replace("0X", "");
                            list.Add(Convert.ToByte(vv));
                        }
                        COM.SendUartData(list.ToArray());
                    }
                    else
                    {
                        COM.SendUartData(t.Text);
                    }
                };
                textlist.Add(tb);
                uartfastsendpanel.Controls.Add(cb);
                uartfastsendpanel.Controls.Add(tb);
                uartfastsendpanel.Controls.Add(bt);
            }
        }

        private void BitmapView_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (scalsize < 20)
                {
                    scalsize++;
                    updateDisplay();
                }
            }
            else
            {
                if (scalsize > 3)
                {
                    scalsize--;
                    updateDisplay();
                }
            }
        }

        bool bitinv = false;//黑白反向
        bool scaninv = true;//扫描反向
        int mode = 0;//取模模式
        string strformat = "0x{0:X2},";

        
        Bitmap selectmap = null;
        int scalsize = 5;
        byte[,] mapdata;
        int[] datacount = new int[256];

        
        class img
        {
            public string name;
            public Bitmap map;
            public bool isString;
            public string info;
            public int fit=128;
            public img(string n, Bitmap m)
            {
                name = n;
                map = m;
                isString = false;
            }
            public img(string n, Bitmap m,string str)
            {
                name = n;
                map = m;
                info = str;
                isString = true;
            }


            public override string ToString()
            {
                return name + "[" + map.Width + "x" + map.Height + "]";
            }
        }

        #region 数码管生成
        Bitmap LEDmap = new Bitmap(240, 240);
        Graphics LEDDraw;

        void DrawLED8(List<Rectangle> rects=null, int b=0,List<int> sets=null)
        {
            Rectangle r;
            int sx = 40;
            int sy = 20;
            string y = "AGD";
            string x = "FEBC";
            for (int i = 0; i < 3; i++)
            {
                LEDDraw.FillRectangle((sets != null && (b & (1 << sets[y[i] - 'A'])) != 0) ? Brushes.Blue : Brushes.Black, r = new Rectangle(sx, sy + i * 80, 80, 20));
                LEDDraw.DrawString(""+y[i], Font, Brushes.Red, sx + 80 / 2-4, sy + i * 80 + 4);
                if (rects != null) rects[y[i] - 'A'] = r;
            }
            for (int i = 0; i < 2; i++)
            {
                LEDDraw.FillRectangle((sets != null && (b & (1 << sets[x[i * 2] - 'A'])) != 0) ? Brushes.Blue : Brushes.Black, r= new Rectangle(sx-20+i*100, sy+20, 20, 80-20));
                LEDDraw.DrawString("" + x[i*2], Font, Brushes.Red, sx - 20 + i * 100+4, sy + 20+60/2-4);
                if (rects != null) rects[x[i * 2] - 'A'] = r;
                LEDDraw.FillRectangle((sets != null && (b & (1 << sets[x[i * 2 + 1] - 'A'])) != 0) ? Brushes.Blue : Brushes.Black,r= new Rectangle(sx-20+i*100, sy+20+80, 20, 80-20));
                LEDDraw.DrawString("" + x[i * 2+1], Font, Brushes.Red, sx - 20 + i * 100+4, sy + 20 + 80 + 60 / 2 - 4);
                if (rects != null) rects[x[i * 2 + 1] - 'A'] = r;
            }

            LEDDraw.FillRectangle((sets != null && (b & (1 << sets['H' - 'A'])) != 0) ? Brushes.Blue : Brushes.Black, r= new Rectangle(sx - 20 + 1 * 100+20, sy + 2 * 80, 20, 20));
            LEDDraw.DrawString("H", Font, Brushes.Red, sx - 20 + 1 * 100+20+5, sy + 2 * 80+5);
            if (rects != null) rects['H' - 'A'] = r;
        }

        void updateLEDData(List<int> blist)
        {
            int[] numsets = {
                '0', 0x3F, '1', 0x06, '2', 0x5B, '3', 0x4F,
                '4', 0x66, '5', 0x6D, '6', 0x7D, '7', 0x07,
                '8', 0x7F, '9', 0x6F
            };
            int[] defsets =  {
                 'A', 0x77, 'a', 0x5F,
                 'B', 0x7F, 'b', 0x7C, 'C', 0x39, 'c', 0x58,
                 'D', 0x3F, 'd', 0x5E, 'E', 0x79, 'e', 0x7B,
                 'F', 0x71, 'f', 0x71, 'G', 0x7D, 'g', 0x6F,
                 'H', 0x76, 'h', 0x74, 'I', 0x06, 'i', 0x04,
                 'J', 0x1E, 'j', 0x1E, 'L', 0x38, 'l', 0x06,
                 'N', 0x37, 'n', 0x54, 'O', 0x3F, 'o', 0x5C,
                 'P', 0x73, 'p', 0x73, 'Q', 0x67, 'q', 0x67,
                 'R', 0x77, 'r', 0x50, 'S', 0x6D, 's', 0x6D,
                 'T', 0x31, 't', 0x78, 'U', 0x3E, 'u', 0x1C,
                 'Y', 0x6E, 'y', 0x6E, 'Z', 0x5B, 'z', 0x5B,
                 '-', 0x40, '_', 0x08, '.', 0x80
            };
            LEDCODETEXT.Text = "";
            for (int k = 0; k < numsets.Length; k += 2)
            {
                int n = numsets[k + 1];
                int v = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (0 != (n & (1 << blist[j])))
                        v |= (1 << blist[j]);
                }
                LEDCODETEXT.AppendText($"0x{(seginv.Checked ? (byte)~v : v):X02},//{(char)numsets[k]}\r\n");
            }
            LEDCODETEXT.AppendText("\r\n");

            if (segspcchar.Checked)
            {
                for (int k = 0; k < defsets.Length; k += 2)
                {
                    int n = defsets[k + 1];
                    int v = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        if (0 != (n & (1 << blist[j])))
                            v |= (1 << blist[j]);
                    }
                    LEDCODETEXT.AppendText($"0x{(seginv.Checked ? (byte)~v : v):X02},//{(char)defsets[k]}\r\n");
                }
            }
        }
        void UpdateLEDMap()
        {
            var list = new List<Rectangle>();
            list.AddRange(new Rectangle[8]);
            DrawLED8(list);
            var blist = new List<int>();
            blist.AddRange(new int[8]);
            var c = tabControl2.TabPages[2].Controls;
            int value = 0;
            for (int i = 0; i < blist.Count; i++)
            {
                blist[i] = i;
            }
            
            for(int i=0;i<8;i++)
            {
                ComboBox cb;
                c.Add(new Label() { Text=""+(char)('A'+i)+"->" ,AutoSize=true,Location=new Point(195, 43-25+i*26) });
                c.Add(cb = new ComboBox() { Text = "BIT" + (char)(i + '0'), Size = new Size(54, 20), Location = new Point(222, 39 - 25 + i * 26), Items = { "BIT0", "BIT1", "BIT2", "BIT3", "BIT4", "BIT5", "BIT6", "BIT7", }, Tag = i }) ;
                cb.SelectedIndexChanged += (s, e) =>
                {
                    var sc = (ComboBox)s;
                    blist[(int)sc.Tag] = sc.SelectedIndex;
                    updateLEDData(blist);
                };
            }
            c.Add(new Label() { Text = "值:", AutoSize = true, Location = new Point(195, 43 - 25 + 8 * 26) });
            TextBox b = new TextBox() { Size = new Size(54, 20), Location = new Point(222, 39 - 25 + 8 * 26),Text="0x00" };
            c.Add(b);
            LEDOUTBOX.MouseDown += (s, e) => { 
                for(int i=0;i<8; i++)
                {
                    if (list[i].Contains(e.X, e.Y))
                    {
                        value ^= (1 << blist[i]);
                        DrawLED8(null, value, blist);
                        LEDOUTBOX.Image = LEDmap;
                        b.Text = $"0x{value:X2}";
                        return;
                    }
                }
            };
            LEDOUTBOX.Image = LEDmap;
            updateLEDData(blist);
            seginv.CheckedChanged += (s, e) =>
            {
                updateLEDData(blist);
            };
            segspcchar.CheckedChanged += (s, e) => { updateLEDData(blist); };
        }
        #endregion

        #region 基础图像处理
        void InitRGB()
        {
            for (int i = 0; i < 256; i++)
            {
                RV[i] = (byte)((double)i * 0.299);
                GV[i] = (byte)((double)i * 0.587);
                BV[i] = (byte)((double)i * 0.114);
            }
        }

        Bitmap toBin(Bitmap graymap, int fv)
        {
            Bitmap binmap = new Bitmap(graymap.Width, graymap.Height, PixelFormat.Format24bppRgb);
            mapdata = new byte[graymap.Width, graymap.Height];
            Rectangle rect = new Rectangle(0, 0, graymap.Width, graymap.Height);
            BitmapData bdata = graymap.LockBits(rect, ImageLockMode.ReadOnly, graymap.PixelFormat);
            int sidlen = bdata.Stride;
            IntPtr dataptr = bdata.Scan0;
            int rowlen = sidlen * graymap.Height;
            byte[] buff = new byte[rowlen];
            Marshal.Copy(dataptr, buff, 0, rowlen);
            int pos = 0;
            byte gray = 0;
            int colorlen = Bitmap.GetPixelFormatSize(graymap.PixelFormat) / 8;
            for (int y = 0; y < graymap.Height; ++y)
            {
                for (int x = 0; x < graymap.Width; ++x)
                {
                    pos = y * sidlen + x * colorlen;
                    gray = (byte)(RV[buff[pos]]+ GV[buff[pos+1]]+ BV[buff[pos+2]]);
                    if (gray > fv)
                    {
                        binmap.SetPixel(x, y, Color.White);
                        mapdata[x, y] = 0;
                    }
                    else
                    {
                        binmap.SetPixel(x, y, Color.Black);
                        mapdata[x, y] = 1;
                    }
                }
            }
            graymap.UnlockBits(bdata);
            return binmap;
        }

        Bitmap toPointMap(Bitmap bit, int psize)
        {
            Bitmap nbit = new Bitmap(bit.Width*psize+1, bit.Height*psize+1);
            Graphics g = Graphics.FromImage(nbit);
            g.Clear(Color.White);
            for (int h = 0; h < bit.Height; h++)
                for (int w = 0; w < bit.Width; w++)
                {
                    //Color c = bit.GetPixel(w, h);
                    //if (c.ToArgb() != Color.White.ToArgb())
                    if (mapdata[w, h] != 0)
                    {
                        g.FillRectangle(Brushes.Black, w * psize, h * psize, psize, psize);
                    }
                }
            for (int h = 0; h < bit.Width+1; h++) g.DrawLine(Pens.Gray, h * psize , 0, h * psize , nbit.Height);
            for (int w = 0; w < bit.Height+1; w++) g.DrawLine(Pens.Gray, 0,w * psize , nbit.Width, w * psize );
            //g.DrawLine(Pens.Gray, bit.Width * psize-1, 0, bit.Width * psize-1, nbit.Height);
            //g.DrawLine(Pens.Gray, 0, bit.Height * psize-1, nbit.Width, bit.Height* psize-1);
            g.Dispose();
            return nbit;
        }


        OpenFileDialog of = new OpenFileDialog();

        void updateDisplay()
        {
            if (imglist.SelectedItem == null) return;
            TextInput.Visible=((img)imglist.SelectedItem).isString;
            if (TextInput.Visible)
                TextInput.Text = ((img)imglist.SelectedItem).info;
            Bitmap map = toBin(((img)imglist.SelectedItem).map, (int)((img)imglist.SelectedItem).map.Tag);
            BitmapView.Image = toPointMap(map, scalsize);
            BitmapView.Width = BitmapView.Image.Width;
            BitmapView.Height = BitmapView.Image.Height;
            int left = Showpanel.Width / 2 - BitmapView.Width / 2;
            BitmapView.Left = left >= 0 ? left : 0;
            int top = Showpanel.Height / 2 - BitmapView.Height / 2;
            BitmapView.Top = top >= 0 ? top : 0;
            GC.Collect();
        }

        Bitmap ImageResize(Bitmap map, int w, int h)
        {
            try
            {
                Bitmap bmap = new Bitmap(w, h);
                Graphics g = Graphics.FromImage(bmap);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(map, new Rectangle(0, 0, w, h), new Rectangle(0, 0, map.Width, map.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return bmap;
            }
            catch { return null; }
        }

        #endregion

        private void addimg_Click(object sender, EventArgs e)
        {
            of.Filter = of.Filter = "图片文件(*.jpg,*.jpeg,*.bmp,*.gif,*.ico,*.png,*.tif,*.wmf )|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf|点阵数据文件(*.dat)|*.dat|文本文件(*.txt)|*.txt";
            if (of.ShowDialog() == DialogResult.OK)
            {
                //EncoderParameters a = new EncoderParameters(2);
                if (of.SafeFileName.ToLower().LastIndexOf(".dat") != -1){
                    SettingWindow ts= new SettingWindow();
                    ts.setSizeWinodow = true;
                    ts.setDataFormatWinodow = false;
                    if (ts.ShowDialog() == DialogResult.OK)
                    {
                        FileStream fs = new FileStream(of.FileName,FileMode.Open);
                        Size s = ts.ImgSize;
                        imglist.Items.Add(new img(of.SafeFileName, BytetoImg(fs, s.Width, s.Height, ts.Mode, ts.BitInv, ts.ScanInv)));
                        if (imglist.SelectedIndex == -1)
                            imglist.SelectedIndex = 0;
                        selectmap = ((img)imglist.SelectedItem).map;
                        updateDisplay();
                    }
                    ts.Dispose();
                }
                else if(of.SafeFileName.ToLower().LastIndexOf(".txt") != -1)
                {
                    try
                    {
                        MessageBox.Show("暂时不支持");
                        //Bitmap desmap = new Bitmap(of.FileName);
                        //Bitmap srcmap = new Bitmap(desmap.Width, desmap.Height);
                        //Graphics g = Graphics.FromImage(srcmap);
                        //g.DrawImageUnscaledAndClipped(desmap, new Rectangle(0, 0, desmap.Width, desmap.Height));
                        //g.Dispose();
                        //desmap.Dispose();
                        //imglist.Items.Add(new img(of.SafeFileName, srcmap));
                        //if (imglist.SelectedIndex == -1)
                        //    imglist.SelectedIndex = 0;
                        //selectmap = ((img)imglist.SelectedItem).map;
                        //updateDisplay();
                    }
                    catch { MessageBox.Show("图片无效"); }
                }
                else if(of.SafeFileName.ToLower().LastIndexOf(".gif") != -1)
                {
                    Image img = Image.FromFile(of.FileName);
                    FrameDimension fd = new FrameDimension(img.FrameDimensionsList[0]);
                    int count = img.GetFrameCount(fd);
                    for (int i = 0; i < count; i++)
                    {
                        img.SelectActiveFrame(fd, i);
                        imglist.Items.Add(new img(of.SafeFileName + "第" + i + "帧", new Bitmap(img)));
                        if (imglist.SelectedIndex == -1)
                            imglist.SelectedIndex = 0;
                    }
                    selectmap = ((img)imglist.SelectedItem).map;
                    updateDisplay();
                }
                else
                    try
                    {
                        Bitmap desmap = new Bitmap(of.FileName);
                        Bitmap srcmap = new Bitmap(desmap.Width, desmap.Height);
                        Graphics g = Graphics.FromImage(srcmap);
                        g.DrawImageUnscaledAndClipped(desmap,new Rectangle(0,0,desmap.Width,desmap.Height));
                        g.Dispose();
                        desmap.Dispose();
                        imglist.Items.Add(new img(of.SafeFileName, srcmap));
                        if (imglist.SelectedIndex == -1)
                            imglist.SelectedIndex = 0;
                        selectmap = ((img)imglist.SelectedItem).map;
                        updateDisplay();
                    }
                    catch { MessageBox.Show("图片无效"); }
            }
        }
        
        private void grayval_Scroll(object sender, EventArgs e)
        {
            selectimg.map.Tag=selectimg.fit = (int)(grayval.Value * 2.55);
            updateDisplay();
        }


        SettingWindow sw = new SettingWindow();
        
        private void editimg_Click(object sender, EventArgs e)
        {
            if (sw.ShowDialog() == DialogResult.OK)
            {
                bitinv = sw.BitInv;
                scaninv = sw.ScanInv;
                mode = sw.Mode;
                strformat = sw.StringFormat;
            }
            //BitmapView.Image = toPointMap((Bitmap)BitmapView.Image, 5);
        }

        int optx=-1, opty=-1,opttype=-1;

        private void BitmapView_MouseMove(object sender, MouseEventArgs e)
        {
            if(selectimg!=null)
                if (editlock.Checked) return;
            if (opttype != -1)
            {
                int x = e.X / scalsize, y = e.Y / scalsize;
                x = x >= selectmap.Width ? selectmap.Width - 1 : x;
                y = y >= selectmap.Height ? selectmap.Height - 1 : y;
                x = x < 0 ? 0 : x;
                y = y < 0 ? 0 : y;

                if (optx == x && opty == y) return;
                optx = x;
                opty = y;
                Bitmap bit = (Bitmap)BitmapView.Image;
                Graphics g = Graphics.FromImage(bit);
                if (opttype == 0)
                {
                    selectmap.SetPixel(x, y, Color.Black);
                    g.FillRectangle(Brushes.Black, x * scalsize, y * scalsize, scalsize, scalsize);
                    mapdata[x, y] = 1;
                }
                else
                {
                    selectmap.SetPixel(x, y, Color.White);
                    g.FillRectangle(Brushes.White, x * scalsize, y * scalsize, scalsize, scalsize);
                    mapdata[x, y] = 0;
                }
                for (int h = 0; h < selectmap.Width + 1; h++) g.DrawLine(Pens.Gray, h * scalsize, 0, h * scalsize, BitmapView.Image.Height);
                for (int w = 0; w < selectmap.Height + 1; w++) g.DrawLine(Pens.Gray, 0, w * scalsize, BitmapView.Image.Width, w * scalsize);
                BitmapView.Image = bit;
                g.Dispose();
            }
        }

        private void BitmapView_MouseDown(object sender, MouseEventArgs e)
        {
            if (BitmapView.Image == null) return;
            if (e.Button == MouseButtons.Left)
                opttype = 0;
            else if (e.Button == MouseButtons.Right)
                opttype = 1;
            else opttype = -1;
        }

        private void BitmapView_MouseUp(object sender, MouseEventArgs e)
        {
            opttype = -1;
            optx = opty = -1;
        }
        byte[] bits = { 0x1, 0x2, 0x4, 0x8, 0x10, 0x20, 0x40, 0x80 };
        byte[] unbits = { 0x80, 0x40, 0x20, 0x10, 0x8, 0x4, 0x2, 0x1 };

        class intsort
        {
            public int k;
            public int v;

            public intsort(int a,int b)
            {
                k = a;
                v = b;
            }
        }

        class intnode
        {
            public intnode next;
            public int value;
            public long bit;
            public intnode(int v,intnode n)
            {
                value = v;
                next = n;
                bit = 0;
            }
        }

        intnode hnode = new intnode(0,null);
        intnode lnode = new intnode(0,null);

        class BitStream
        {
            int index;
            int pos;
            int size;
            byte[] buff;
            byte[] bits = { 0x80, 0x40, 0x20, 0x10, 0x8, 0x4, 0x2, 0x1 };
            public BitStream(byte[] buff)
            {
                this.index = 0;
                this.pos = 0;
                this.buff = buff;
                this.size = buff.Length * 8;
                //this.buff[0] = 0;
            }

            public void Reset()
            {
                if (this.index != 0) pos++;
                this.index = 0;
                for(int i=0;i< pos; i++)
                {
                    buff[i] = 0;
                }
                this.pos = 0;
            }

            public int Count
            {
                get { return index + pos * 8; }
                private set { }
            }

            public bool Writebit(bool bit)
            {
                if (size - 1 <= index) return false;
                if(bit)
                    buff[pos]|= bits[index++];
                else
                    buff[pos] &=(byte)~bits[index++];
                if (index == 8)
                {
                    buff[++pos]=0;
                    index = 0;
                }
                return true;
            }

            public bool Writebits(int b,int len)
            {
                if (len == 0) return true;
                if (size - len <= index) return false;
                if (index + len <= 8)
                {
                    buff[pos] |= (byte)(b << (8-len-index));
                    if(index + len==8)
                    {
                        pos++;
                        index = 0;
                    }
                    else
                    {
                        index += len;
                    }
                }
                else
                {
                    b<<= ((8 - (len&7) + 8 - index)&7);
                    int loop = 1 + (index + len) / 8;
                    for(int i=0;i<loop;i++)
                    {
                        int sf = 8 * (loop - i - 1);
                        buff[pos + i] |= (byte)(b >> sf);
                    }
                    pos += loop-1;
                    index = (index+len) & 7;
                    
                }
                return true;
            }

            public bool WriteByte(byte b)
            {
                if (size - 8 <= index) return false;
                if (index == 0)
                {
                    buff[pos++] = b;
                }
                else
                {
                    int v = b;
                    v <<= 8 - index;
                    buff[pos++]|=(byte)(v>>8);
                    buff[pos] = (byte)v;
                }
                return true;
            }

            public bool WriteStream(BitStream bs)
            {
                if (bs == null) return false;
                if (size - bs.Count <= index) return false;
                for(int i = 0; i < bs.Count / 8; i++)
                {
                    this.WriteByte(bs.buff[i]);
                }
                if ((bs.Count & 7) != 0)
                {
                    this.Writebits(bs.buff[bs.Count / 8 ]>> (8-bs.Count & 7), bs.Count & 7);
                }
                return true;
            }
            
            public byte[] toBytes()
            {
                int len = (this.buff.Length == pos ? pos : index == 0 ? pos : pos + 1);
                byte[] outdata = new byte[len];
                Buffer.BlockCopy(this.buff, 0, outdata, 0, len);
                return outdata;
            }

            public bool ReadBit()
            {

                bool flag = (buff[pos] & bits[index]) != 0;
                if (++index >= 8)
                {
                    index = 0;
                    pos++;
                }
                return flag;
            }

            public byte ReadByte()
            {
                if (size - 8 <= index) return 0;
                byte data;
                if (index == 0)
                {
                    data = buff[pos++];
                }
                else
                {
                    data = buff[pos++];
                    data <<= (8 - index);
                    data |= (byte)(buff[pos]>>index);
                }
                return data;
            }

            public int ReadBits(int len)
            {
                int data = 0;
                if ((index + len) <= 8)
                {
                    data = buff[pos];
                    data <<= index;
                    data = (byte)data;
                    data <<= len;
                    if (index+len == 8)
                    {
                        index = 0;
                        pos++;
                    }
                    else
                    {
                        index += len;
                    }
                    data =(byte)(data >> 8);
                }
                else
                {
                    int loop = (index + len) / 8 + 1;
                    data = 0;
                    for(int i=0;i< loop; i++)
                    {
                        if (i >= 4) break;
                        data <<= 8;
                        data |= buff[pos++];
                    }
                    data >>= ((8 - (len & 7) + 8 - index) & 7);
                    if (loop > 4)
                    {
                        data |= buff[pos]>>(8-index);
                    }
                    index += len;
                    index &= 7;
                }
                return data&(~(-1<<len));
            }



        }

        string byte2Hex(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                if ((i % 16) == 0)
                {
                    sb.AppendLine();
                }
                sb.AppendFormat(strformat, bytes[i]);
            }
            return sb.ToString();
        }
        byte[] buildDatamap(byte[,] map,Size size)
        {
            byte[] data = null;
            int w, h;
            int x, y;
            int t, dat;
            int count = 0;
            byte[] bitstats = new byte[8];

            switch (mode)
            {
                case 0:
                    w = size.Width;
                    h = (size.Height + 7) / 8;
                    data = new byte[w * h];
                    for (y = 0; y < h; y++)
                    {
                        for (x = 0; x < w; x++)
                        {
                            dat = 0;
                            for (int i = 0; i < 8; i++)
                            {
                                int hv = i + y * 8;
                                if (hv >= size.Height)
                                {
                                    if (!scaninv)
                                        dat <<= 1;
                                    else
                                        dat >>= 1;
                                    continue;
                                }
                                if (!scaninv)
                                {
                                    dat <<= 1;
                                    if (map[x, hv] != 0)
                                        dat++;
                                }
                                else
                                {
                                    dat >>= 1;
                                    if (map[x, hv] != 0)
                                        dat |= 0x80;
                                }
                            }
                            if (bitinv)
                                data[count++] = (byte)~dat;
                            else
                                data[count++] = (byte)dat;
                        }
                    }
                    break;
            }
            return data;
        }
        byte[] imgtoByte()
        {
            byte[] data = null;
            int w, h;
            int x, y;
            int t, dat;
            int count = 0;
            byte[] bitstats = new byte[8];

            switch (mode)
            {
                case 0:
                    w = selectmap.Width;
                    h = (selectmap.Height + 7) / 8;
                    data = new byte[w * h];
                    for (y = 0; y < h; y++)
                    {
                        for (x = 0; x < w; x++)
                        {
                            dat = 0;
                            for (int i = 0; i < 8; i++)
                            {
                                int hv = i + y * 8;
                                if (hv >= selectmap.Height)
                                {
                                    if (!scaninv)
                                        dat <<= 1;
                                    else
                                        dat >>= 1;
                                    continue;
                                }
                                if (!scaninv)
                                {
                                    dat <<= 1;
                                    if (mapdata[x, hv] != 0)
                                        dat++;
                                }
                                else
                                {
                                    dat >>= 1;
                                    if (mapdata[x, hv] != 0)
                                        dat |= 0x80;
                                }
                            }
                            if (bitinv)
                                data[count++] = (byte)~dat;
                            else
                                data[count++] = (byte)dat;
                        }
                    }
                    break;
            }
            return data;
        }

        Bitmap BytetoImg(Stream data, int w, int h, int mode, bool binv, bool sinv)
        {
            Bitmap map = new Bitmap(w, h);
            Color pointcolor = binv ? Color.White : Color.Black;
            Graphics g = Graphics.FromImage(map);
            g.Clear(binv ? Color.Black : Color.White);
            g.Dispose();
            int x, y;
            int t, dat;
            int hv = (h + 7) / 8;
            int count = 0;
            switch (mode)
            {
                case 0:
                    for (y = 0; y < hv; y++)
                    {
                        for (x = 0; x < w; x++)
                        {
                            dat = data.ReadByte();
                            for (t = 0; t < 8; t++)
                            {
                                if (!sinv)
                                {
                                    if ((dat & 0x80) != 0)
                                    {
                                        map.SetPixel(x, y*8 + t, pointcolor);
                                    }
                                    dat <<= 1;
                                }
                                else
                                {
                                    if ((dat & 1) != 0)
                                    {
                                        map.SetPixel(x, y * 8 + t, pointcolor);
                                    }
                                    dat >>= 1;
                                }
                            }
                        }
                    }
                    break;
            }

            return map;

        }

        Bitmap LoadBinData(byte[] data, int w, int h, int mode, bool binv, bool sinv)
        {
            MemoryStream ms = new MemoryStream(data);
            return BytetoImg(ms, w, h, mode, binv, sinv);
        }

        private void build_Click(object sender, EventArgs e)
        {
            if (selectmap == null) return;
            byte[] imgdata=imgtoByte();
            if (imgdata == null)
            {
                MessageBox.Show("图片无效");
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("//图片["+((img)imglist.SelectedItem).name + "] " + selectmap.Width + "x" + selectmap.Height);
            if (enablezip.Checked)
            {
                imgdata = encode(imgdata, zipmode.SelectedIndex);
            }
            for(int i = 0; i < imgdata.Length; i++)
            {
                if ((i % 16) == 0)
                {
                    sb.AppendLine();
                }
                sb.AppendFormat(strformat, imgdata[i]);
            }
            OutPutData.Text = sb.ToString();
        }

        public byte[] encode(byte[] code,int mode)
        {
            BitStream bs = new BitStream(new byte[code.Length]);
            byte[] bytecount = new byte[256];
            foreach(byte b in code)
            {
                bytecount[b]++;
            }
            List<intsort> sort = new List<intsort>();
            for (int i = 0; i < 256; i++)
                if (bytecount[i] != 0)
                    sort.Add(new intsort(i, bytecount[i]));
            sort.Sort((intsort a, intsort b) => { return a.v > b.v ? -1 : a.v == b.v ? 0 : 1; });
            List<int> KeyTable = new List<int>();
            bs.WriteByte((byte)sort.Count);
            foreach (intsort sr in sort)
            {
                bs.WriteByte((byte)sr.k);
                KeyTable.Add(sr.k);
            }
            


            return bs.toBytes();
        }


        NewPanle np = new NewPanle();
        int count = 1;
        private void newimage_Click(object sender, EventArgs e)
        {
            if (np.ShowDialog() == DialogResult.OK)
            {
                if (np.TYPE())
                {
                    var str = np.TEXTValue();
                    if (str.Length == 0) return;
                    if (np.splittext())
                    {
                        foreach(var sstr in str)
                        {
                            Size s = np.getSize();
                            Bitmap bs = new Bitmap(s.Width, s.Height);
                            Graphics gx = Graphics.FromImage(bs);
                            gx.Clear(Color.White);
                            gx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                            //var str=np.TEXTValue();
                            using (Font f = new Font(Font.FontFamily, (s.Width * 72 / 96)))
                            {
                                gx.DrawString(sstr+"", f, Brushes.Black, 0 - np.stringoffset(), 0);
                            }
                            gx.Dispose();
                            imglist.Items.Add(new img("字符" + count++, bs, sstr+""));
                            if (imglist.SelectedIndex == -1)
                                imglist.SelectedIndex = 0;
                            selectmap = ((img)imglist.SelectedItem).map;
                        }
                        updateDisplay();
                    }
                    else
                    {
                        Size s = np.getSize();
                        int len=0;
                        foreach(var ss in str)
                            if (ss > 127)
                                len += 2;
                            else len += 1;
                        Bitmap bs = new Bitmap(s.Width*len/2, s.Height);
                        Graphics gx = Graphics.FromImage(bs);
                        gx.Clear(Color.White);
                        gx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                        //var str=np.TEXTValue();
                        using (Font f = new Font(Font.FontFamily, (s.Width * 72 / 96)))
                        {
                            gx.DrawString(str + "", f, Brushes.Black, 0 - np.stringoffset(), 0);
                        }
                        gx.Dispose();
                        imglist.Items.Add(new img("字符" + count++, bs, str));
                        if (imglist.SelectedIndex == -1)
                            imglist.SelectedIndex = 0;
                        selectmap = ((img)imglist.SelectedItem).map;
                        updateDisplay();
                    }
                }
                else
                {
                    Size s = np.getSize();
                    Bitmap bs = new Bitmap(s.Width, s.Height);
                    Graphics gx = Graphics.FromImage(bs);
                    gx.Clear(Color.White);
                    gx.Dispose();
                    imglist.Items.Add(new img("新图像" + count++, bs));
                    if (imglist.SelectedIndex == -1)
                        imglist.SelectedIndex = 0;
                    selectmap = ((img)imglist.SelectedItem).map;
                    updateDisplay();
                }
            }
        }

        private void rmimg_Click(object sender, EventArgs e)
        {
            int index = imglist.SelectedIndex;
            if (index != -1)
                imglist.Items.RemoveAt(index);
            if (imglist.Items.Count != 0)
            {
                index--;
                if (index < 0) index = 0;
                imglist.SelectedIndex = index;
                selectmap = ((img)imglist.SelectedItem).map;
                updateDisplay();
            }
            else
            {
                selectmap = null;
                BitmapView.Image = null;
            }
            

        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(OutPutData.Text);
        }

        SaveFileDialog sf = new SaveFileDialog();
        private void 保存为文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectmap == null) return;
            sf.Filter = "数据文件(*.dat)|*.dat";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sf.FileName, FileMode.OpenOrCreate);
                byte[] imgdata = imgtoByte();
                if (imgdata == null)
                {
                    MessageBox.Show("图片无效");
                }
                if (enablezip.Checked)
                {
                    imgdata = encode(imgdata, zipmode.SelectedIndex);
                }
                fs.Write(imgdata, 0, imgdata.Length);
                fs.Flush();
                fs.Close();
                MessageBox.Show("保存成功");
            }
        }

        ResizeImage resizeimg = new ResizeImage();
        private img selectimg;
        private Font selectfont;

        private void resizebutton_Click(object sender, EventArgs e)
        {
            if (selectmap == null) return;
            resizeimg.ImgSize = new Size(selectmap.Width, selectmap.Height);
            if (resizeimg.ShowDialog() == DialogResult.OK)
            {
                Size s = resizeimg.ImgSize;
                int gray = (int)selectmap.Tag;
                ((img)imglist.SelectedItem).map = selectmap = ImageResize(selectmap, s.Width, s.Height);
                selectmap.Tag = gray;
                updateDisplay();
            }
        }

        public Bitmap ConvertTo24bppTo1bpp(Bitmap SrcImg)
        {


            //unsafe
            //{
            //    byte* SrcPointer, DestPointer;
            //    int Width, Height, SrcStride, DestStride;
            //    int X, Y, Index, Sum; ;
            //    Bitmap DestImg = new Bitmap(SrcImg.Width, SrcImg.Height, PixelFormat.Format1bppIndexed);
            //    BitmapData SrcData = new BitmapData();
            //    SrcImg.LockBits(new Rectangle(0, 0, SrcImg.Width, SrcImg.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb, SrcData);
            //    BitmapData DestData = new BitmapData();
            //    DestImg.LockBits(new Rectangle(0, 0, SrcImg.Width, SrcImg.Height), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed, DestData);
            //    Width = SrcImg.Width; Height = SrcImg.Height; SrcStride = SrcData.Stride; DestStride = DestData.Stride;
            //    for (Y = 0; Y < Height; Y++)
            //    {
            //        SrcPointer = (byte*)SrcData.Scan0 + Y * SrcStride;
            //        DestPointer = (byte*)DestData.Scan0 + Y * DestStride;
            //        Index = 7; Sum = 0;
            //        for (X = 0; X < Width; X++)
            //        {
            //            if (*SrcPointer + (*(SrcPointer + 1) << 1) + *(SrcPointer + 2) >= 512) Sum += (1 << Index);
            //            if (Index == 0)
            //            {
            //                *DestPointer = (byte)Sum;
            //                Sum = 0;
            //                Index = 7;
            //                DestPointer++;
            //            }
            //            else
            //                Index--;
            //            SrcPointer += 3;
            //        }
            //        if (Index != 7) *DestPointer = (byte)Sum;
            //    }
            //    SrcImg.UnlockBits(SrcData);
            //    DestImg.UnlockBits(DestData);
            //    return DestImg;
            //}
            return null;
        }

        private void saveimg_Click(object sender, EventArgs e)
        {
            if (selectmap == null) return;
            sf.Filter = "BMP图片|*.bmp";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                Bitmap savebitmap = new Bitmap(selectmap.Width, selectmap.Height, PixelFormat.Format1bppIndexed);
                BitmapData imgdata = new BitmapData();
                savebitmap.LockBits(new Rectangle(0, 0, savebitmap.Width, savebitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed, imgdata);
                int stride = imgdata.Stride;
                int w = (selectmap.Width + 7) / 8;
                byte[] buff = new byte[w];
                for (int y = 0; y < selectmap.Height; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        byte dat = 0;
                        for (int i = 0; i < 8; i++)
                        {
                            int pos = x * 8 + i;
                            if (pos >= selectmap.Width) break;
                            dat <<= 1;
                            if (mapdata[pos, y] != 0)
                                dat++;
                        }
                        buff[x] = (byte)~dat;
                    }
                    Marshal.Copy(buff, 0, imgdata.Scan0 + y * stride, buff.Length);
                }
                savebitmap.UnlockBits(imgdata);
                savebitmap.Save(sf.FileName,ImageFormat.Bmp);
                MessageBox.Show("保存完成");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LEDDraw = Graphics.FromImage(LEDmap);
            UpdateLEDMap();
        }

        private void TextInput_TextChanged(object sender, EventArgs e)
        {

        }
        FontDialog fd = new FontDialog();
        private Bitmap fontmap;
        private Graphics fontdraw;
        private Bitmap modmap;
        private Graphics moddraw;

        private void fontselectBT_Click(object sender, EventArgs e)
        {
            if (fd.ShowDialog() == DialogResult.OK)
            {
                selectfont = new Font(fd.Font.FontFamily, fd.Font.Size * 72 / 96, fd.Font.Style);
                fontsizelabel4.Text = "" + selectfont.Size * 96 / 72;
                fonttypelabel.Text = selectfont.Name;
                fonttestTB.Font = selectfont;
                //fontdraw.Clear(Color.White);
                //fontdraw.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                //fontdraw.DrawString("测试123ABC", selectfont, Brushes.Black, 0, 0);
                //fontprepictureBox1.Image = fontmap;
                fonttestTB_TextChanged(null, null);
            }
        }

        private void fonttestTB_TextChanged(object sender, EventArgs e)
        {
            if (fonttestTB.Text.Length == 0) return;
            int size = int.Parse((string)fontsizeselectCB.SelectedItem);
            int w = size;
            int xoffset = fontsizeselectCB.SelectedIndex + 2;
            if (fonttestTB.Text[0] < 128)
                w /= 2;
            using (Font f = new Font(selectfont.FontFamily, (size * 72 / 96),selectfont.Style))
            {
                moddraw.Clear(Color.White);
                moddraw.DrawString(""+fonttestTB.Text[0], f, Brushes.Black, 0-xoffset, 0);

                fontdraw.Clear(Color.White);

                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        if (modmap.GetPixel(x, y).R != 255)
                            fontdraw.FillRectangle(Brushes.Black, x * 4, y * 4, 4, 4);
                        else
                            fontdraw.DrawRectangle(Pens.Red, x * 4, y * 4, 4, 4);
                    }
                }

                fontprepictureBox1.Image = fontmap;
            }
        }

        MemoryStream buildall(bool ascii=false)
        {

            MemoryStream data = new MemoryStream();
            int w, h;
            int x, y;
            int t, dat;
            int count = 0;

            int size = int.Parse((string)fontsizeselectCB.SelectedItem);
            int xoffset = fontsizeselectCB.SelectedIndex + 2;
            byte[] hzvalue = new byte[2];

            for(hzvalue[0]=(byte)(fonta1a9CB.Checked?0xa1:0xb0);hzvalue[0]<0xF8;hzvalue[0]++)
            for (hzvalue[1] = 0xa1; hzvalue[1] < 0xff; hzvalue[1]++)
            {
                    if (ascii)
                    {
                        if (hzvalue[1] == 0xa1)
                            hzvalue[0] = 31;
                        hzvalue[1] = 0;
                        hzvalue[0]++;
                        if (hzvalue[0] == 127)
                        {
                            return data;
                        }
                    }
                string hz = Encoding.Default.GetString(hzvalue);
                    if (hzvalue[0] > 0xa9 && hzvalue[0] < 0xb0)
                        hz = "  ";
                 using (Font f = new Font(selectfont.FontFamily, (size * 72 / 96),selectfont.Style))
                {
                    moddraw.Clear(Color.White);
                    moddraw.DrawString(hz, f, Brushes.Black, 0 - xoffset, 0);
                    switch (mode)
                    {
                        case 0:
                            w = size;
                                if (ascii)
                                    w /= 2;
                            h = (size + 7) / 8;
                                for (y = 0; y < h; y++)
                                {
                                    for (x = 0; x < w; x++)
                                    {
                                        dat = 0;
                                        for (int i = 0; i < 8; i++)
                                        {
                                            int hv = i + y * 8;
                                            if (hv >= size)
                                            {
                                                if (!scaninv)
                                                    dat <<= 1;
                                                else
                                                    dat >>= 1;
                                                continue;
                                            }
                                            if (!scaninv)
                                            {
                                                dat <<= 1;
                                                if (modmap.GetPixel(x, hv).R != 255)
                                                    dat++;
                                            }
                                            else
                                            {
                                                dat >>= 1;
                                                if (modmap.GetPixel(x, hv).R != 255)
                                                    dat |= 0x80;
                                            }
                                        }
                                        if (bitinv)
                                            data.WriteByte((byte)~dat);
                                        else
                                            data.WriteByte((byte)dat);
                                    }
                                }
                            break;
                    }
                }
            }
            return data;
        }

        private void buildfontlibbutton10_Click(object sender, EventArgs e)
        {
            sf.Filter = "字库数据|*.dat";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                var ms = buildall(((Control)sender).Tag!=null);
                FileStream fs = new FileStream(sf.FileName, FileMode.OpenOrCreate);
                var data = ms.ToArray();
                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();
                ms.Dispose();
            }
        }

        private void fontsomtcheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(fontsomtcheckBox3.Checked)
                moddraw.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            else
                moddraw.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
        }




        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                switch (tabControl2.SelectedIndex)
                {
                    case 1:
                        if (selectdrag != null)
                            selectdrag.RemoveSelect();
                        break;
                }
            }
        }


        #region ToolsControl
        private void uartsend_Click(object sender, EventArgs e)
        {
            COM.SendUartData(tb_uarttx.Text);
        }

        private void uart_clearrx_Click(object sender, EventArgs e)
        {
            tb_uartrx.Text = "";
        }
        #endregion

        #region LayerControl
        easydrag selectdrag;
        newLayer newLayer=new newLayer();
        int layercount = 0;
        private void b_newlayer_Click(object sender, EventArgs e)
        {
            if (newLayer.ShowDialog() == DialogResult.OK)
            {
                Size s = newLayer.LayerSize;
                if (s.Width == 0 || s.Height == 0)
                {
                    MessageBox.Show("尺寸错误");
                    return;
                }
                var view = new ListViewItem("层" + layercount++);
                var pic = new PictureBox() { Location = new Point(0, 0), Size = layerpanel.Size };
                
                layerpanel.Controls.Clear();
                layerpanel.Controls.Add(pic);
                view.Tag = new easydrag(pic, s) { Update=(b)=> { pic.Image = b;pic.Width = b.Width;pic.Height = b.Height;pic.Left = (pic.Parent.Width - pic.Width) / 2; pic.Left = pic.Left < 0 ? 0 : pic.Left; pic.Top = (pic.Parent.Height - pic.Height) / 2; pic.Top = pic.Top < 0 ? 0 : pic.Top; } };
                layerlistView1.Items.Add(view);
                view.Selected = true;
                layercontrol.SelectedIndex = layercontrol.SelectedIndex+1;
            }
        }
        private void layercontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayerImageView.Nodes.Clear();
            for(int i=0;i<imglist.Items.Count;i++)
            {
                img img = (imglist.Items[i] as img);
                LayerImageView.Nodes.Add(new TreeNode() { Text = img.name, Tag = img.map });
            }
        }
        private void layerlistView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (layerlistView1.SelectedItems.Count == 0) return;
            if (selectdrag == layerlistView1.SelectedItems[0].Tag as easydrag) return;
            layerpanel.Controls.Clear();
            selectdrag = layerlistView1.SelectedItems[0].Tag as easydrag;
            layerpanel.Controls.Add(selectdrag.Control);
            selectdrag.updateAll();
        }
        private void b_deletlayer_Click(object sender, EventArgs e)
        {
            if (selectdrag == null) return;
            layerpanel.Controls.Clear();
            layerlistView1.SelectedItems[0].Remove();
            if (layerlistView1.Items.Count > 0)
                layerlistView1.Items[0].Selected = true;
        }
        private void layerbuildcode_Click(object sender, EventArgs e)
        {
            if(selectdrag == null) return;
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            List<Bitmap> b = new List<Bitmap>();
            int count = 0;
            foreach(var item in selectdrag.Items)
            {
                if (!b.Contains(item.map))
                {
                    b.Add(item.map);
                    sb.Append($"const unsigned char img{count++}[]={{//{item.map.Width}x{item.map.Height}");
                    sb.AppendLine(byte2Hex(buildDatamap(item.mapdata, item.map.Size)));
                    sb.AppendLine("\n};\r\n\r\n");
                }
            }
            
            sb.AppendLine($"void layer{layerlistView1.SelectedIndices[0]}(){{");
            int id = 0;
            foreach (var item in selectdrag.Items)
            {
                sb.AppendLine($"\tDrawObject({id++},{item.box.X},{item.box.Y},{item.box.Width},{item.box.Height},img{b.IndexOf(item.map)});\n");
            }
            sb.AppendLine("}\n");
            layeroutput.Text = sb.ToString();
        }

        private void layertoimg_Click(object sender, EventArgs e)
        {
            if(selectdrag==null) return;
            imglist.Items.Add(new img("新图像" + count++, selectdrag.DrawDataMap()));
            if (imglist.SelectedIndex == -1)
                imglist.SelectedIndex = 0;
            selectmap = ((img)imglist.SelectedItem).map;
            updateDisplay();
        }
        #endregion
        #region BitmapListControl
        private void editlock_CheckedChanged(object sender, EventArgs e)
        {
            if (selectimg != null)
                if (selectimg.isString)
                {
                    selectimg.isString = editlock.Checked;
                    updateDisplay();
                }
        }
        private void buildallimg_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int k=0;k<imglist.Items.Count;k++)
            {
                imglist.SelectedItem = imglist.Items[k];
                byte[] imgdata = imgtoByte();
                if (imgdata == null)
                {
                    MessageBox.Show("图片无效");
                    continue;
                }
                
                sb.AppendLine("//图片[" + ((img)imglist.SelectedItem).name + "] " + selectmap.Width + "x" + selectmap.Height);
                if (enablezip.Checked)
                {
                    imgdata = encode(imgdata, zipmode.SelectedIndex);
                }
                for (int i = 0; i < imgdata.Length; i++)
                {
                    if ((i % 16) == 0)
                    {
                        sb.AppendLine();
                    }
                    sb.AppendFormat(strformat, imgdata[i]);
                }
                sb.AppendLine();
            }
            OutPutData.Text = sb.ToString();

        }

        private void BitmapView_MouseClick(object sender, MouseEventArgs e)
        {
            BitmapView_MouseMove(null, e);
            //if (BitmapView.Image == null) return;
            //int type;
            //if (e.Button == MouseButtons.Left)
            //    type = 0;
            //else if (e.Button == MouseButtons.Right)
            //    type = 1;
            //else type = -1;
            //if (type == -1) return;
            //int x=e.X/scalsize, y=e.Y/scalsize;
            //x = x >= selectmap.Width ? selectmap.Width - 1 : x;
            //y = y >= selectmap.Height ? selectmap.Height - 1 : y;
            //if (optx == x && opty == y&&opttype==type) return;
            //optx = x;
            //opty = y;
            //opttype = type;
            //Bitmap bit = (Bitmap)BitmapView.Image;
            //Graphics g = Graphics.FromImage(bit);
            //if (selectmap.GetPixel(x, y).ToArgb()!=Color.Black.ToArgb())
            //{
            //    selectmap.SetPixel(x, y, Color.Black);
            //    g.FillRectangle(Brushes.Black, x * scalsize, y * scalsize, scalsize, scalsize);
            //}
            //else
            //{
            //    selectmap.SetPixel(x, y, Color.White);
            //    g.FillRectangle(Brushes.White, x * scalsize, y * scalsize, scalsize, scalsize);
            //}
            //for (int h = 0; h < selectmap.Width + 1; h++) g.DrawLine(Pens.Gray, h * scalsize, 0, h * scalsize, BitmapView.Image.Height);
            //for (int w = 0; w < selectmap.Height + 1; w++) g.DrawLine(Pens.Gray, 0, w * scalsize, BitmapView.Image.Width, w * scalsize);
            //BitmapView.Image = bit;
            //g.Dispose();
        }

        private void imglist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imglist.SelectedIndex == -1) return;
            selectmap = ((img)imglist.SelectedItem).map;
            if (selectmap.Tag == null)
                selectmap.Tag = 128;
            grayval.Value= (int)((int)selectmap.Tag/2.55);
            selectimg = (img)imglist.SelectedItem;
            editlock.Checked = selectimg.isString;
            updateDisplay();
        }

        #endregion
    }
}
