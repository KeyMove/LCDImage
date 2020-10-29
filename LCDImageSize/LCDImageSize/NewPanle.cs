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

        public bool TYPE()
        {
            return textselectradioButton1.Checked;
        }

        public string TEXTValue()
        {
            return TextValue.Text;
        }

        public int stringoffset()
        {
            return textsizecomboBox1.SelectedIndex + 2;
        }

        int w, h;

        private void IntInput(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void textselectradioButton1_CheckedChanged(object sender, EventArgs e)
        {
            WidthValue.Enabled = !textselectradioButton1.Checked;
            HeightValue.Enabled = !textselectradioButton1.Checked;
            TextValue.Enabled = textselectradioButton1.Checked;
            textsizecomboBox1.Enabled = textselectradioButton1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textselectradioButton1.Checked)
            {
                h = w = int.Parse(textsizecomboBox1.Text);
            }
            else
            {
                w = int.Parse(WidthValue.Text);
                h = int.Parse(HeightValue.Text);
            }
        }
    }
}
