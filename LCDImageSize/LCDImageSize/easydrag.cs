using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LCDImageSize
{
    internal class easydrag
    {
        public class dragObject
        {
            public Rectangle box;
            public Bitmap map;
            public byte[,] mapdata;

            public void append(dragObject obj)
            {
                if (obj.mapdata == null) return;
                for (int y = 0; y < obj.box.Height; y++)
                {
                    for (int x = 0; x < obj.box.Width; x++)
                    {
                        int px = obj.box.X + x;
                        int py = obj.box.Y + y;
                        if (px < 0 || py < 0) continue;
                        if (px >= box.Width || py >= box.Height) continue;
                        mapdata[px, py] |= obj.mapdata[x, y];
                    }
                }
            }

            public void clear()
            {
                for(int y=0; y<box.Height; y++)
                    for(int x=0; x < box.Width; x++)
                    {
                        mapdata[x, y] = 0;
                    }
            }
        }
        public Action<Bitmap> Update { get; set; } = (b) => { };
        
        List<dragObject> list=new List<dragObject>();
        int scalsize = 5;
        int lastscal = 0;
        dragObject select = null;
        Rectangle selectrect=new Rectangle(0,0,0,0);
        List<dragObject> selects = new List<dragObject>();
        List<Point> selectpoints = new List<Point>();
        public int Fit { get; set; } = 128;
        //public byte[,] DataMap { get; set; } = null;
        Bitmap mainMap;
        Graphics mainDraw;
        dragObject mainObj;
        Control srccontrol, dstcontrol;
        public Control Control { get { return dstcontrol; } }
        bool drag = false;
        public List<dragObject> Items { get { return list; } }

        public void RemoveSelect()
        {
            foreach(var obj in selects)
            {
                list.Remove(obj);
            }
            selects.Clear();
            updateAll();
        }

        static public Control setDrag
        {
            set {
                var src = value;
                src.AllowDrop = true;
                if (src is ListView)
                    (src as ListView).ItemDrag += (s, e) =>
                    {
                        src.DoDragDrop(((src as ListView).SelectedItems[0].Tag), DragDropEffects.Move);
                    };
                if (src is TreeView)
                {
                    (src as TreeView).ItemDrag += (s, e) =>
                    {
                        src.DoDragDrop(((e.Item as TreeNode).Tag), DragDropEffects.Move);
                    };
                }
                src.DragEnter += (s, e) => { e.Effect = e.AllowedEffect; };
            }
            get { return null; }
        }
        Point ScalPoint(Point p)
        {
            int x = p.X / scalsize, y = p.Y / scalsize;
            x = x >= mainMap.Width ? mainMap.Width - 1 : x;
            y = y >= mainMap.Height ? mainMap.Height - 1 : y;
            x = x < 0 ? 0 : x;
            y = y < 0 ? 0 : y;
            return new Point(x, y);
        }
        public easydrag(Control dst,Size size)
        {
            dstcontrol = dst;
            dst.AllowDrop = true;
            dst.DragEnter += (s, e) => { e.Effect = e.AllowedEffect; };
            dst.DragDrop += (s, e) => {
                Bitmap img = e.Data.GetData(typeof(Bitmap)) as Bitmap;
                if (img == null) return;
                var p = ScalPoint(dst.PointToClient(new Point(e.X, e.Y)));
                list.Add(new dragObject() { box = new Rectangle(p.X, p.Y, img.Width, img.Height), map = img, mapdata = toBin(img, (img.Tag==null?Fit:(int)img.Tag)) });
                updateAll();
            };
            

            mainMap = new Bitmap(size.Width,size.Height);
            mainDraw = Graphics.FromImage(mainMap);
            mainObj = new dragObject() { box=new Rectangle(0,0,size.Width,size.Height),mapdata= new byte[size.Width, size.Height] };

            Point selectPoint=new Point(0,0);
            dst.MouseDown += (s, e) =>
            {
                drag = true;
                select = null;
                var p = ScalPoint(e.Location);
                foreach (var item in list)
                {
                    selectrect.Location = e.Location;
                    if (item.box.Contains(p.X, p.Y))
                    {
                        select = item;
                        selectPoint = new Point(p.X - select.box.X, p.Y - select.box.Y);
                        if (selects.Contains(item))
                        {
                            selectpoints.Clear();
                            foreach(var i in selects)
                            {
                                selectpoints.Add(new Point(p.X-i.box.X,p.Y-i.box.Y));
                            }
                        }
                        else
                        {
                            selects.Clear();
                            selects.Add(item);
                            selectpoints.Add(selectPoint);
                        }
                        return;
                    }
                }
                selects.Clear();
            };
            int optx = 0, opty = 0;
            dst.MouseMove += (s, e) =>
            {
                if (!drag) return;
                if (select == null)
                {
                    selectrect.Width = e.X - selectrect.X;
                    selectrect.Height = e.Y - selectrect.Y;

                    updateAll();
                    return;
                }
                var p=ScalPoint(e.Location);
                var tp = new Point(p.X - selectPoint.X, p.Y - selectPoint.Y);
                if (optx == p.X && opty == p.Y) return;
                optx = p.X;
                opty = p.Y;
                for (int i = 0; i < selects.Count; i++)
                {
                    selects[i].box.X = p.X - selectpoints[i].X;
                    selects[i].box.Y = p.Y - selectpoints[i].Y;
                }
                //select.box.X = tp.X;
                //select.box.Y = tp.Y;
                updateAll();
            };
            dst.MouseUp += (s, e) =>
            {
                drag = false;
                if (select == null)
                {
                    if (selectrect.Width != 0 && selectrect.Height != 0)
                    {
                        Rectangle r = selectrect;
                        if (r.Width < 0) { r.X += r.Width; r.Width = -r.Width; }
                        if (r.Height < 0) { r.Y += r.Height; r.Height = -r.Height; }
                        r.Location = ScalPoint(r.Location);
                        var sz=ScalPoint(new Point(r.Size.Width,r.Size.Height));
                        r.Size = new Size(sz.X, sz.Y);
                        foreach (var item in list)
                        {
                            if (r.Contains(item.box.Location) ||
                            r.Contains(item.box.X + item.box.Width / 2, item.box.Y + item.box.Height / 2) ||
                            r.Contains(item.box.X + item.box.Width, item.box.Y + item.box.Height) ||
                            r.Contains(item.box.X + item.box.Width, item.box.Y) ||
                            r.Contains(item.box.X , item.box.Y + item.box.Height)
                            )
                            {
                                selects.Add(item);
                                continue;
                            }
                        }
                    }
                }
                selectpoints.Clear();
                selectrect.Width = selectrect.Height = 0;
                
                updateAll();
            };
            dst.MouseWheel += (s, e) =>
            {
                
                if (e.Delta > 0)
                {
                    if (scalsize < 20)
                    {
                        scalsize++;
                        updateAll();
                    }
                }
                else
                {
                    if (scalsize > 3)
                    {
                        scalsize--;
                        updateAll();
                    }
                }
            };
            
            InitRGB();
        }
        static byte[] RV;
        static byte[] GV;
        static byte[] BV;
        static void InitRGB()
        {
            if (RV != null) return;
            RV = new byte[256];
            GV = new byte[256];
            BV = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                RV[i] = (byte)((double)i * 0.299);
                GV[i] = (byte)((double)i * 0.587);
                BV[i] = (byte)((double)i * 0.114);
            }
        }
        
        Bitmap toBin(Bitmap graymap, int fv, byte[,] mapdata)
        {
            Bitmap binmap = new Bitmap(graymap.Width, graymap.Height, PixelFormat.Format24bppRgb);
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
                    gray = (byte)(RV[buff[pos]] + GV[buff[pos + 1]] + BV[buff[pos + 2]]);
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
        byte[,] toBin(Bitmap graymap, int fv)
        {
            byte[,] mapdata=new byte[graymap.Width, graymap.Height];
            //Bitmap binmap = new Bitmap(graymap.Width, graymap.Height, PixelFormat.Format24bppRgb);
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
                    gray = (byte)(RV[buff[pos]] + GV[buff[pos + 1]] + BV[buff[pos + 2]]);
                    if (gray > fv)
                    {
                        //binmap.SetPixel(x, y, Color.White);
                        mapdata[x, y] = 0;
                    }
                    else
                    {
                        //binmap.SetPixel(x, y, Color.Black);
                        mapdata[x, y] = 1;
                    }
                }
            }
            graymap.UnlockBits(bdata);
            return mapdata;
        }
        Bitmap scalMap;
        Graphics scalDraw;
        Bitmap toPointMap(Bitmap bit, byte[,] MapData,Rectangle rect)
        {
            Bitmap nbit = scalMap;
            Graphics g = scalDraw;
            g.Clear(Color.White);
            
            for (int h = 0; h < bit.Height; h++)
                for (int w = 0; w < bit.Width; w++)
                {
                    //Color c = bit.GetPixel(w, h);
                    //if (c.ToArgb() != Color.White.ToArgb())
                    if (MapData[w, h] != 0)
                    {
                        g.FillRectangle(Brushes.Black, w * lastscal, h * lastscal, lastscal, lastscal);
                    }
                }
            for (int h = 0; h < bit.Width + 1; h++) g.DrawLine(Pens.Gray, h * lastscal, 0, h * lastscal, nbit.Height);
            for (int w = 0; w < bit.Height + 1; w++) g.DrawLine(Pens.Gray, 0, w * lastscal, nbit.Width, w * lastscal);
            if (selects.Count>0)
            {
                foreach (var item in selects)
                {
                    Rectangle r = new Rectangle(item.box.X * lastscal, item.box.Y * lastscal, item.box.Width * lastscal, item.box.Height * lastscal);
                    g.DrawRectangle(Pens.Red, r);
                }
                if (drag)
                {

                    bool xl = false, yl = false;

                    foreach (var item in list)
                    {
                        if (selects.Contains(item)) continue;
                        if (!xl)
                        {
                            if (item.box.Y == rect.Y)
                            {
                                g.DrawLine(Pens.Aqua, 0, rect.Y * lastscal, mainObj.box.Width * lastscal, rect.Y * lastscal);
                                xl = true;
                            }
                            else if ((item.box.Y + item.box.Height) == (rect.Height + rect.Y))
                            {
                                g.DrawLine(Pens.Aqua, 0, (rect.Height + rect.Y) * lastscal, mainObj.box.Width * lastscal, (rect.Height + rect.Y) * lastscal);
                                xl = true;
                            }
                        }
                        if (!yl)
                        {
                            if (item.box.X == rect.X)
                            {
                                g.DrawLine(Pens.Aqua, rect.X * lastscal, 0, rect.X * lastscal, mainObj.box.Height * lastscal);
                                yl = true;
                            }
                            else if ((item.box.X + item.box.Width) == (rect.Width + rect.X))
                            {
                                g.DrawLine(Pens.Aqua, (item.box.X + item.box.Width) * lastscal, 0, (item.box.X + item.box.Width) * lastscal, (mainObj.box.Height) * lastscal);
                                yl = true;
                            }
                        }
                        if (xl && yl) break;
                    }
                }
                
            }
            if (selectrect.Width != 0 || selectrect.Height != 0)
            {
                Rectangle r = selectrect;
                if (r.Width < 0) { r.X += r.Width;r.Width=-r.Width; }
                if(r.Height<0) { r.Y += r.Height; r.Height = -r.Height; }
                g.DrawRectangle(Pens.Red, r);
            }

            //g.DrawLine(Pens.Gray, bit.Width * psize-1, 0, bit.Width * psize-1, nbit.Height);
            //g.DrawLine(Pens.Gray, 0, bit.Height * psize-1, nbit.Width, bit.Height* psize-1);
            return nbit;
        }
        Bitmap toPointMap(Bitmap bit, int psize, byte[,] MapData)
        {
            Bitmap nbit = new Bitmap(bit.Width * psize + 1, bit.Height * psize + 1);
            Graphics g = Graphics.FromImage(nbit);
            g.Clear(Color.White);
            for (int h = 0; h < bit.Height; h++)
                for (int w = 0; w < bit.Width; w++)
                {
                    //Color c = bit.GetPixel(w, h);
                    //if (c.ToArgb() != Color.White.ToArgb())
                    if (MapData[w, h] != 0)
                    {
                        g.FillRectangle(Brushes.Black, w * psize, h * psize, psize, psize);
                    }
                }
            for (int h = 0; h < bit.Width + 1; h++) g.DrawLine(Pens.Gray, h * psize, 0, h * psize, nbit.Height);
            for (int w = 0; w < bit.Height + 1; w++) g.DrawLine(Pens.Gray, 0, w * psize, nbit.Width, w * psize);
            //g.DrawLine(Pens.Gray, bit.Width * psize-1, 0, bit.Width * psize-1, nbit.Height);
            //g.DrawLine(Pens.Gray, 0, bit.Height * psize-1, nbit.Width, bit.Height* psize-1);
            g.Dispose();
            return nbit;
        }

        public void updateAll()
        {
            if (mainMap == null) return;
            if (scalsize != lastscal)
            {
                lastscal = scalsize;
                if (scalMap != null)
                {
                    scalMap.Dispose();
                    scalDraw.Dispose();
                }
                scalMap = new Bitmap(mainMap.Width * scalsize + 1, mainMap.Height * scalsize + 1);
                scalDraw = Graphics.FromImage(scalMap);
            }
            mainObj.clear();
            foreach (var item in list)
            {
                mainObj.append(item);
            }
            if (select == null)
            {
                Update(toPointMap(mainMap, mainObj.mapdata, Rectangle.Empty));
                return;
            }
            mainDraw.DrawRectangle(Pens.Red, select.box);
            //Bitmap map = toBin(select.map, Fit,DataMap);
            
            Update(toPointMap(mainMap, mainObj.mapdata, select.box));
            GC.Collect();
        }


    }
}
