using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        Point[] points = new Point[100];
        Rectangle rect;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            
            rect.X = e.X; rect.Width = 35;
            rect.Y = e.Y; rect.Height = 35;

            Brush brush = new SolidBrush(Color.FromArgb(100,20,20,20));
            g.FillEllipse(brush, rect);
            g.Dispose();
            brush.Dispose();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
