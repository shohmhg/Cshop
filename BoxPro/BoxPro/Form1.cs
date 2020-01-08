using System;
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
                    {0,1,0 },
                    {0,1,0 },
                    {0,1,0 },
                    {0,1,0 },
                    {0,0,1 },
                    {0,1,0 },
                    {1,0,0 },
                    {1,0,0 },
                    {1,0,0 },
                    {0,1,0 },
                    {1,0,0 },
                    {0,1,0 },
                    {0,1,0 },
                    {0,1,0 },
                    {0,1,0 },
                    {0,0,1 },
                    {0,1,0 },
                    {1,0,0 },
                    {1,0,0 },
                    {1,0,0 },
                    {0,1,0 },
                    {1,0,0 }
               };
        static int CurrentStageNote;
        public int[,] Stage1_Graphic = new int[8,3];
        public void Shift(KeyEventArgs e)
        {
            int[,] Clone = (int[,])Stage1_Graphic.Clone();
            Graphics g = CreateGraphics();

            for (int i = 0; i < Stage1_Graphic.GetLength(0) - 1; i++) 
            {
                for (int j = 0; j < 3; j++)
                {
                    Clone[i + 1, j] = Stage1_Graphic[i, j];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (CurrentStageNote >= 0)
                    Clone[0, i] = Stage1[CurrentStageNote, i];
                else
                    Clone[0, i] = 0;
            }
            CurrentStageNote--;


            for (int i = 0; i < Stage1_Graphic.GetLength(0); i++)
            {
                for (int j = 0; j < Stage1_Graphic.GetLength(1); j++)
                {
                    Stage1_Graphic[i, j] = Clone[i, j];
                }
            }



            //if((e.KeyCode == Keys.Left && Stage1[Stage1.GetLength(0) - 1, 0] == 1 )||
            //   (e.KeyCode == Keys.Right&& Stage1[Stage1.GetLength(0) - 1, 2] == 1 )||
            //   (e.KeyCode == Keys.Down && Stage1[Stage1.GetLength(0) - 1, 1] == 1 )||
            //   (e.KeyCode == Keys.Up   && Stage1[Stage1.GetLength(0) - 1, 1] == 1 ))
            //{
            //    for (int i = 0; i < Stage1.GetLength(0) - 1; i++)
            //    {
            //        for (int j = 0; j < Stage1.GetLength(1); j++)
            //        {
            //            if (i == 0)
            //                Clone[i, j] = 0;

            //            Clone[i + 1, j] = Stage1[i, j];
            //        }
            //    }

            //    for (int i = 0; i < Stage1.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < Stage1.GetLength(1); j++)
            //        {
            //            //g.DrawString(""+Clone[i, j], Font, Brushes.Black, j*10, i*10);
            //            Stage1[i, j] = Clone[i, j];
            //        }
            //    }            
            //}
            Invalidate();
        }
        public Form1()
        {
            InitializeComponent();

            //Stage1의 최하단 행 저장
            CurrentStageNote = Stage1.GetLength(0) - 1 - 7;
            //Stage1_Grahphic 배열 초기화
            int k = 0;
            for (int i = Stage1.GetLength(0) - 7; i < Stage1.GetLength(0); i++)
            {
                for (int j = 0; j < Stage1.GetLength(1); j++)
                {
                    Stage1_Graphic[k, j] = Stage1[i, j];
                }
                k++;
            }
        }

        private void Form1_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void ticktock_Tick(object sender, EventArgs e)
        {
            
        }

        private void Represher_Tick(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle();
            int Box_Width = 40, Box_Height = Box_Width;
            int Box_X = Box_Width + Box_Width/2, Box_Y = Box_Height + Box_Height/2;

            for (int i = 0; i < Stage1_Graphic.GetLength(0); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    e.Graphics.DrawString("" + Stage1_Graphic[i, j], Font, Brushes.Black, j * 10, i * 10);
                    if(Stage1_Graphic[i,j] == 1)
                    {
                        rect.X = Box_X * j;
                        rect.Y = Box_Y * i;
                        rect.Width = Box_Width;
                        rect.Height = Box_Height;

                        e.Graphics.DrawRectangle(Pens.Black, rect);
                    }
                }
            }
            //for (int i = 0; i < Stage1.GetLength(0); i++)
            //{
            //    for (int j = 0; j < Stage1.GetLength(1); j++)
            //    {
            //        if (Stage1[i, j] == 1)
            //        {
            //            rect.X = Box_X * j;
            //            rect.Y = Box_Y * i;
            //            rect.Width = Box_Width;
            //            rect.Height = Box_Height;

            //            e.Graphics.DrawRectangle(Pens.Black, rect);
            //        }
            //    }
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Shift(e);
        }
    }
}

