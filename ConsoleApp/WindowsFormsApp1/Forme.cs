using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Forme : Form
    {
        public Forme()
        {
            InitializeComponent();
        }

        private void Forme_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.DrawString("hello world", Font, Brushes.Black, 10, 10);
            
        }

        private void Forme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
                MessageBox.Show("keydown");
            
        }

        private void Forme_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("KEYPRESS");
        }
    }
}
