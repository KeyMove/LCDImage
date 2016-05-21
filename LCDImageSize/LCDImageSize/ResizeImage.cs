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
    public partial class ResizeImage : Form
    {
        public ResizeImage()
        {
            InitializeComponent();
        }

        int w, h;
        bool updatechar=false;

        public Size ImgSize
        {
            get { return new Size(w, h); }
            set { w = value.Width;h = value.Height; }
        }

        protected override void OnShown(EventArgs e)
        {
            if (resizemode.Checked)
            {
                HValue.Text = "" + h;
                WValue.Text = "" + w;
            }
            else
            {
                HValue.Text = WValue.Text = "100";
            }
            base.OnShown(e);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int savew = w,saveh=h;
            try
            {
                w = int.Parse(WValue.Text);
                h = int.Parse(HValue.Text);
                if (!resizemode.Checked)
                {
                    double v = savew;
                    v *= w;
                    v /= 100;
                    w = (int)v;
                    v = saveh;
                    v *= h;
                    v /= 100;
                    h = (int)v;
                }
            }
            catch
            {
                w = savew;
                h = saveh;
            }
        }

        private void WValue_TextChanged(object sender, EventArgs e)
        {
            if (!standwh.Checked) return;
            if (!updatechar) return;
            updatechar = false;
            double value;
            try
            {
                value=int.Parse(WValue.Text);
                if (resizemode.Checked)
                {
                    value /= w;
                    HValue.Text = "" + ((int)(h * value));
                }
                else
                {
                    HValue.Text = "" + ((int)value);
                }
            }
            catch { }
            
        }

        private void HValue_TextChanged(object sender, EventArgs e)
        {
            if (!standwh.Checked) return;
            if (!updatechar) return;
            updatechar = false;
            double value;
            try
            {
                value = int.Parse(HValue.Text);
                if (resizemode.Checked)
                {
                    value /= h;
                    WValue.Text = "" + ((int)(w * value));
                }
                else
                {
                    WValue.Text = "" + ((int)value);
                }
            }
            catch { }
        }

        private void resizemode_CheckedChanged(object sender, EventArgs e)
        {
            if (resizemode.Checked)
            {
                HValue.Text = "" + h;
                WValue.Text = "" + w;
            }
            else
            {
                HValue.Text = WValue.Text = "100";
            }
        }

        private void IntInput(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            updatechar = true;
        }
    }
}
