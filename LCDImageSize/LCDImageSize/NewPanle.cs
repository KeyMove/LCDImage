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
    public partial class NewPanle : Form
    {
        public NewPanle()
        {
            InitializeComponent();
        }

        public Size getSize()
        {
            return new Size(w, h);
        }

        int w, h;

        private void IntInput(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            w = int.Parse(WidthValue.Text);
            h = int.Parse(HeightValue.Text);
        }
    }
}
