using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PIDHelper
{
    public class COMHelper
    {

        public interface COMHandle
        {
            void Send(byte[] data);
        }

        Control handle;
        public SerialPort COM;

        int[] bpslist = { 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000, 921600 };
        bool isOpen = false;
        public List<byte> rxbuffer = new List<byte>(4096);
        int lastCount = 0;
        int lastPos = 0;
        private int rxtimeout;
        bool beforSend;


        ComboBox comselect = new System.Windows.Forms.ComboBox();
        ComboBox bpsselect = new System.Windows.Forms.ComboBox();
        Button getcombutton13 = new System.Windows.Forms.Button();
        Button opencom = new System.Windows.Forms.Button();

        public Action OnOpenCOM;
        public Action OnCloseCOM;
        public Action On1SCheck;//1秒检测串口是否关闭
        TextBox datainfo;
        TextBox txinfo;


        public void SendUartData(string str, bool updateinfo = true)
        {
            if (!COM.IsOpen) return;
            if(datainfo!=null)
                datainfo.Invoke(new MethodInvoker(()=> {
                    datainfo.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] 发送: " + str);
                }));
            if(txinfo!=null)
                if (updateinfo)
                    txinfo.Text = str;
            beforSend = true;
            COM.Write(str);
        }

        public void SendUartDataNoLog(string str)
        {
            if (!COM.IsOpen) return;
            beforSend = true;
            COM.Write(str);
        }

        public void SendUartData(byte[] data)
        {
            if (!COM.IsOpen) return;
            COM.Write(data, 0, data.Length);
        }

        private void getPortDeviceName()
        {
            using (System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher
            ("select * from Win32_PnPEntity where Name like '%(COM%'"))
            {
                var hardInfos = searcher.Get();
                foreach (var hardInfo in hardInfos)
                {
                    if (hardInfo.Properties["Name"].Value != null)
                    {
                        string deviceName = hardInfo.Properties["Name"].Value.ToString();
                        comselect.Items.Add(deviceName);
                    }
                }
            }
        }

        void init()
        {
            this.bpsselect.FormattingEnabled = true;
            this.bpsselect.Location = new System.Drawing.Point(5, 53);
            this.bpsselect.Name = "bpsselect";
            this.bpsselect.Size = new System.Drawing.Size(121, 20);
            this.bpsselect.TabIndex = 4;

            this.comselect.FormattingEnabled = true;
            this.comselect.Location = new System.Drawing.Point(5, 20);
            this.comselect.Name = "comselect";
            this.comselect.Size = new System.Drawing.Size(handle.Size.Width-15-43, 20);
            this.comselect.TabIndex = 3;

            this.getcombutton13.Location = new System.Drawing.Point(handle.Size.Width - 5- 43, 18);
            this.getcombutton13.Name = "getcombutton13";
            this.getcombutton13.Size = new System.Drawing.Size(42, 23);
            this.getcombutton13.TabIndex = 2;
            this.getcombutton13.Text = "刷新";
            this.getcombutton13.UseVisualStyleBackColor = true;
            this.getcombutton13.Click += new System.EventHandler(this.getcombutton13_Click);

            this.opencom.Location = new System.Drawing.Point(handle.Size.Width-75-5, 51);
            this.opencom.Name = "opencom";
            this.opencom.Size = new System.Drawing.Size(75, 23);
            this.opencom.TabIndex = 2;
            this.opencom.Text = "打开串口";
            this.opencom.UseVisualStyleBackColor = true;
            this.opencom.Click += new System.EventHandler(this.opencom_Click);
        }

        void COM_Close()
        {
            if(COM.IsOpen)
                COM.Close();
            isOpen = false;
            comselect.Enabled = true;
            bpsselect.Enabled = true;
            getcombutton13.Enabled = true;
            opencom.Text = "打开串口";
            try
            {
                if (OnCloseCOM != null)
                    OnCloseCOM();
                
            }
            catch { }
        }

        void COM_Open()
        {
            try
            {
                int start = comselect.Text.IndexOf("(COM") + 1;
                int end = 0;
                foreach (char c in comselect.Text.Substring(start + 3))
                {
                    if (c > '9' || c < '0') break;
                    end++;
                }
                COM.PortName = comselect.Text.Substring(start, end + 3);
                COM.BaudRate = bpslist[bpsselect.SelectedIndex];
                COM.Open();
                comselect.Enabled = false;
                bpsselect.Enabled = false;
                getcombutton13.Enabled = false;
                opencom.Text = "关闭串口";
                isOpen = true;
                if (OnOpenCOM != null)
                    OnOpenCOM();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开串口失败\r\n" + ex.Message);
                return;
            }
        }

        private void opencom_Click(object sender, EventArgs e)
        {
            if (COM.IsOpen)
            {
                COM_Close();
            }
            else
            {
                if (comselect.Items.Count == 0)
                {
                    MessageBox.Show("无可用端口");
                    return;
                }
                COM_Open();
            }
        }

        private void getcombutton13_Click(object sender, EventArgs e)
        {
            comselect.Items.Clear();
            getPortDeviceName();
            opencom.Enabled = comselect.Items.Count != 0;
            if (comselect.Items.Count != 0)
                comselect.SelectedIndex = 0;
        }

        public COMHelper(Control host,TextBox rxtextbox=null, TextBox txtextbox =null)
        {
            handle = host;
            datainfo = rxtextbox;
            txinfo = txtextbox;

            handle.Controls.Add(comselect);
            handle.Controls.Add(getcombutton13);
            handle.Controls.Add(bpsselect);
            handle.Controls.Add(opencom);


            init();



            //获取串口
            foreach (int i in bpslist)
            {
                bpsselect.Items.Add(i);
                //setbpscomboBox1.Items.Add(i)
            }
            bpsselect.SelectedIndex = 8;
            getcombutton13_Click(null, null);

            COM = new SerialPort();
            COM.BaudRate = (int)bpsselect.SelectedItem;
            COM.Parity = Parity.None;
            COM.DataBits = 8;
            COM.StopBits = StopBits.One;
            COM.DataReceived += COM_DataReceived;
            COM.ReadTimeout = 5;
            COM.ReadBufferSize = 51200;
            COM.ReadTimeout = 10;

            //定时检测串口是否意外关闭
            Timer comcheck = new Timer();
            comcheck.Interval = 1000;
            comcheck.Tick += (object sender, EventArgs e) => {
                if (isOpen == true && COM.IsOpen == false)
                {
                    COM_Close();
                }
                if (On1SCheck != null)
                    On1SCheck();
            };
            comcheck.Start();

            if (datainfo != null)
            {
                Point oldPoint = datainfo.Location;
                Size oldSize = datainfo.Size;
                int Ymax = datainfo.Location.Y > 500 ? 500 : datainfo.Location.Y;
                datainfo.MouseWheel += (object sender, MouseEventArgs e) =>
                {
                    if (e.Delta > 0)
                    {
                        datainfo.Focus();
                        datainfo.Size = new Size(datainfo.Size.Width, Ymax - oldSize.Height);
                        datainfo.Location = new Point(datainfo.Location.X, oldPoint.Y - (Ymax - oldSize.Height *2));
                    }
                    else
                    {
                        //datainfo.Location = new Point(datainfo.Location.X, 542 );
                        //datainfo.Size = new Size(datainfo.Size.Width, 49);
                    }
                };

                datainfo.LostFocus += (object sender, EventArgs e) =>
                {
                    datainfo.Size = oldSize;
                    datainfo.Location = oldPoint;
                };

                datainfo.KeyPress
                    += (object sender, KeyPressEventArgs e) =>
                    {
                        if (e.KeyChar == (char)Keys.Escape)
                        {
                            datainfo.Size = oldSize;
                            datainfo.Location = oldPoint;
                        }
                    };
            }
        }

        

        private void COM_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            rxtimeout = 0;
            byte[] temp = new byte[COM.BytesToRead];
            COM.Read(temp, 0, temp.Length);
            rxbuffer.AddRange(temp);
        }
    }
}
