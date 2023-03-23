using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trigomultidirectionaldraw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        float cx, cy, px, py;
        float rad = (float)(180 / Math.PI);
        int mod = -1;
        int del0 = 0;
        int dim = 50;
        int pozy = 250;
        Pen pen0;
        public List<Point> pointsSin = new List<Point>();
        public List<Point> pointsCos = new List<Point>();
        public double secanta(double x)
        {
            return 1 / x;
        }

        public double cosecanta(double x)
        {
            return 1 / x;
        }

        public bool drawfunction()
        {
            if (del0 == 1)
            {
                g.Clear(this.BackColor);
            }
            for (float i = 0.0f; i < 360.0f; i += 0.500f)
            {
                try
                {
                    px = cx;
                    py = cy;
                    //textBox1.Text += "\r\n";
                    //textBox1.Text += Math.Sin(i).ToString();
                    //textBox1.Text += Math.Cos(i).ToString();
                    //textBox1.Text += Math.Tan(i).ToString();
                    //textBox1.Text += ( Math.Cos(i)/Math.Sin(i)).ToString();
                    //textBox1.Text += secanta(Math.Cos(i)).ToString();
                    //textBox1.Text += cosecanta(Math.Sin(i)).ToString();
                    if (mod == 0)
                    {
                        cy = (float)(Math.Sin(i / rad)) * dim + pozy;
                        pen0 = new Pen(Color.Black);
                        pointsSin.Add(new Point((int)cx,(int)cy));

                    }
                    else if (mod == 1)
                    {
                        cy = (float)(Math.Cos(i / rad)) * dim + pozy;
                        pen0 = new Pen(Color.Red);
                        pointsCos.Add(new Point((int)cx, (int)cy));
                    }
                    else if (mod == 2)
                    {
                        cy = (float)(Math.Tan(i / rad)) * dim + pozy;
                        pen0 = new Pen(Color.Green);
                    }
                    else if (mod == 3)
                    {

                        cy = (float)((Math.Cos(i / rad) / Math.Sin(i * rad))) * dim + pozy;
                        pen0 = new Pen(Color.White);
                    }
                    else if (mod == 4)
                    {
                        cy = (float)(secanta(Math.Cos(i / rad))) * dim + pozy;
                        pen0 = new Pen(Color.Silver);
                    }
                    else if (mod == 5)
                    {
                        cy = (float)(cosecanta(Math.Sin(i / rad))) * dim + pozy;
                        pen0 = new Pen(Color.Blue);
                    }


                    cx = i * 2;
                    g.DrawLine(pen0, px, py, cx, cy);
                }
                catch { }
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            g = CreateGraphics();
        }


        public void runall()
        {
            mod = 2;
            drawfunction();

            mod = 3;
            drawfunction();

            mod = 4;
            drawfunction();

            mod = 5;
            drawfunction();
        }

        public void drawAllLinesSin2Cos()
        {
            if (pointsCos.Count == pointsSin.Count)
            {
                for (int i = 0; i < pointsSin.Count; i++)
                {
                    g.DrawLine(pen0, pointsSin[i], pointsCos[i]);
                }
            }
        }

        public void drawAllLinesSin2CosDifference()
        {
            if (pointsCos.Count == pointsSin.Count && pointsCos.Count!=0)
            {
                for (int i = 0; i < pointsSin.Count; i++)
                {
                    g.DrawLine(pen0, pointsSin[i].X - pointsCos[i].X+ pointsSin[i].X, pointsSin[i].Y, pointsCos[i].X, pointsCos[i].Y);
                }
            }
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Width = 1024;
            g = CreateGraphics();

            mod = 0;
            drawfunction();

            pozy = 400;
            mod = 1;
            drawfunction();


            //g.Clear(this.BackColor);

            drawAllLinesSin2Cos();

            drawAllLinesSin2CosDifference();
        }
    }
}
