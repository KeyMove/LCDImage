using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCDImageSize
{
    public partial class SettingWindow : Form
    {
        Timer updatemap = new Timer();
        Bitmap b = new Bitmap(81, 81);
        Graphics g;

        int mode = 0;
        int count=0;
        int dw, dh;
        public SettingWindow()
        {
            InitializeComponent();
            updatemap.Interval = 100;
            updatemap.Tick += T_Tick;
            g = Graphics.FromImage(b);
            showdemo.Image = b;
            selectmode.SelectedIndex = 0;
            dw = (b.Width / 5);
            dh = (b.Height / 5);
        }

        public int Mode
        {
            get { return mode; }
            private set { }
        }

        public bool ScanInv
        {
            get { return rv1.Checked; }
            private set { }
        }

        public bool BitInv
        {
            get { return !rc1.Checked; }
            private set { }
        }
        
        public string StringFormat
        {
            get { return codemode.Text; }
            private set { }
        }

        private void SettingWindow_Load(object sender, EventArgs e)
        {

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            g.Clear(Color.White);
            count = 0;
            updatemap.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (count == (16 * 16))
            {
                count = 0;
            }
            switch (mode)
            {
                case 0:
                    if (rv1.Checked)
                    {
                        g.FillRectangle(Brushes.Black, ((count % (16 * 8)) / 8) * 5, ((count % 8)+(count/(8*16))*8) * 5, 5, 5);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Black, ((count % (16 * 8)) / 8) * 5, (7 - (count % 8) + (count / (8 * 16)) * 8) * 5, 5, 5);
                    }
                    break;
                case 1:
                    if (rv1.Checked)
                    {
                        g.FillRectangle(Brushes.Black, ((count % 8)+((count/(16*8))*8)) * 5, ((count% (16 * 8)) / 8) * 5, 5, 5);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Black, (7-(count % 8) + ((count / (16 * 8)) * 8)) * 5, ((count % (16 * 8)) / 8) * 5, 5, 5);
                    }
                    break;
                case 2:
                    if (rv1.Checked)
                    {
                        g.FillRectangle(Brushes.Black, (count % (dw)) * 5, (count / (dw)) * 5, 5, 5);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Black, (dw-1-(count % (dw))) * 5, (count / (dw)) * 5, 5, 5);
                    }
                    break;
                case 3:
                    if (rv1.Checked)
                    {
                        g.FillRectangle(Brushes.Black, (count / (dh)) * 5, (count % (dh)) * 5, 5, 5);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Black, (count / (dh)) * 5, (dh-1-(count % (dh))) * 5, 5, 5);
                    }
                    break;
            }
            g.DrawLine(Pens.Gray, 0, 0, b.Width, 0);
            g.DrawLine(Pens.Gray, 0, b.Height-1, b.Width, b.Height-1);
            g.DrawLine(Pens.Gray, 0, 0, 0, b.Height);
            g.DrawLine(Pens.Gray, b.Width-1, 0, b.Width-1, b.Height);
            for (int x = 1; x < b.Width/5; x++)
                g.DrawLine(Pens.Gray, x * 5, 0, x * 5, b.Height);
            for (int y = 1; y < 16; y++)
                g.DrawLine(Pens.Gray, 0, y * 5, b.Width, y * 5);
            showdemo.Image = b;
            count++;
        }

        private void updateselect(object sender, EventArgs e)
        {
            count=0;
            g.Clear(Color.White);
        }

        private void updateselect2(object sender, EventArgs e)
        {
            count = 0;
            g.Clear(Color.White);
            mode = selectmode.SelectedIndex;
        }
    }
}
