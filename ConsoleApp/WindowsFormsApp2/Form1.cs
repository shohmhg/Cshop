using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int x, y;
        List<Point> points = new List<Point>();
        int CurrentPoints = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            if (points.Count == 3)
                points.Clear();
            points.Add(point);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            string str = points.Count + "";
            e.Graphics.DrawString(str, Font, Brushes.Black, 0, 0);
            if (points.Count >= 2)
            {
                e.Graphics.DrawLine(Pens.Black, points[0], points[1]);

            }
            if (points.Count == 3)
            {
                e.Graphics.DrawLine(Pens.Black, points[2], points[0]);
                e.Graphics.DrawLine(Pens.Black, points[1], points[2]);
            }
        }
    }
}
