using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCue
{
    public partial class Form1 : Form
    {
        Rectangle[] rect;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Brushes.Black);
            e.Graphics.DrawRectangles(pen, rect);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rect = new Rectangle[100];
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int a;
            for(int i=0; i<rect.Length;i++)
            {
                rect[i].X = rand.Next(0, 400);
                rect[i].Y = rand.Next(0, 400);
                a = rand.Next(0, 100);
                rect[i].Width = a;
                rect[i].Height = a;
            }
            
            Invalidate();
        }

        private void Form1_Layout(object sender, LayoutEventArgs e)
        {
            Width = 500;
            Height = 500;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
