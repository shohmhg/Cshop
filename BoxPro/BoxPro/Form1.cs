﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxPro
{
    public partial class Form1 : Form
    {
        public int[,] Stage1
           = new int[,]
               {
                    {0,0,0 },
                    {1,1,1 },
                    {0,1,0 },
                    {0,0,0 },
                    {0,0,0 },
                    {1,1,1 },
                    {0,1,0 },
                    {0,0,0 },
                    {0,0,0 },
                    {1,1,1 },
                    {0,1,0 },
                    {0,0,0 },
                    {0,0,0 },
                    {1,1,1 },
                    {0,1,0 },
                    {0,0,0 }

               };

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void ticktock_Tick(object sender, EventArgs e)
        {
            int[,] Clone = Stage1;
            Graphics g = CreateGraphics();

            for (int i = 0; i < Stage1.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < Stage1.GetLength(1); j++)
                {
                    if (i == 0)
                        Clone[i, j] = 0;
                    else
                        Clone[i + 1, j] = Stage1[i, j];

                }
            }

            for (int i = 0; i < Stage1.GetLength(0); i++)
            {
                for (int j = 0; j < Stage1.GetLength(1); j++)
                {
                    g.DrawString(""+Clone[i, j], Font, Brushes.Black, j*10, i*10);
                    //Stage1[i, j] = Clone[i, j];
                }
            }
            

            //Invalidate();
        }

        private void Represher_Tick(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle();
            int Box_Width = 10, Box_Height = 10;
            int Box_X = Box_Width, Box_Y = Box_Height;


            for (int i = 0; i < Stage1.GetLength(0); i++)
            {
                for (int j = 0; j < Stage1.GetLength(1); j++)
                {
                    if (Stage1[i, j] == 1)
                    {
                        rect.X = Box_X * j;
                        rect.Y = Box_Y * i;
                        rect.Width = Box_Width;
                        rect.Height = Box_Height;

                        e.Graphics.DrawRectangle(Pens.Black, rect);
                    }
                }
            }
        }
    }
}
