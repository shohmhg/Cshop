using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleBufferd
{
    public partial class Form1 : Form
    {
        BufferedGraphicsContext context;
        BufferedGraphics graphics;
        Image image;
        public Form1()
        {
            InitializeComponent();

            context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = new Size(800, 600);
            graphics = context.Allocate(CreateGraphics(),
                                                new Rectangle(0, 0, 800, 600));
            graphics.Graphics.Clear(Color.Yellow);
            image = Image.FromFile("224ee79f0a1d842de81523b2662973ea.jpg");
            SetClientSizeCore(800, 600);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Random rand = new Random();
            for(int i=0; i<99999; i++)
            {
                graphics.Graphics.DrawImage(image,
                            rand.Next(0, 600), rand.Next(0, 400));
            }

            graphics.Render(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
