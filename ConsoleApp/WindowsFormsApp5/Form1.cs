using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    class getout
    {
        public static string coop;
    }
    class getout2
    {
        public static string coop2;
    }
    public partial class Form1 : Form
    {
        public static string Coop { get; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Image image = Image.FromFile("african-cape-buffalo.jpg");
            SetClientSizeCore(image.Width, image.Height);
            e.Graphics.DrawImage(image, 0, 0);

            getout ou;
            ou. = getout2.coop2;
            a = "sa";
            string str = "a" + a + "Coop" + Coop;
            e.Graphics.DrawString(str, Font, Brushes.Black, 0, 0);
        }
    }
}
