using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LCDImageSize
{
    public partial class newLayer : Form
    {
        public newLayer()
        {
            InitializeComponent();
        }

        public Size LayerSize
        {
            get
            {
                try
                {

                    int w = int.Parse(textBox1.Text);
                    int h = int.Parse(textBox2.Text);
                    return new Size(w, h);
                }
                catch { return new Size(0,0); }
            }
            private set { }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
