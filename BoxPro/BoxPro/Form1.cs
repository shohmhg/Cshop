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
        public int[,] Stage1 = new int[,]
            {
                        {0,1,0 },
                        {0,1,0 },
                        {0,1,0 },
                        {0,1,0 },
                        {0,0,1 },
                        {0,0,1 },
                        {0,1,0 },
                        {0,0,1 },
                        {0,0,1 },
                        {1,1,1 },
                        {1,0,1 },
                        {1,1,0 },
                        {1,0,1 },
                        {0,1,0 },
                        {0,1,0 },
                        {0,1,0 },
                        {0,1,0 },
                        {0,0,1 },
                        {0,0,1 },
                        {0,1,0 },
                        {1,0,0 },
                        {1,0,0 },
                        {0,1,0 },
                        {1,0,0 },
                        {1,0,0 },
                        {0,1,0 },
                        {0,1,0 },
                        {0,1,0 }
           };

        static int CurrentStageNote;
        public int[,] Stage1_Graphic = new int[8,3];
        public int[] KEY = new int[] { 0, 0, 0 };
        public int Count = 0;

        public void Shift()
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

            Invalidate();
        }
        
        public void Represher_()    //게임 초기화
        {
            
            //Stage1의 최하단 행 저장
            CurrentStageNote = Stage1.GetLength(0) - 1 - 8;

            //Stage1_Grahphic 배열 초기화
            int k = 0;
            for (int i = Stage1.GetLength(0) - 8; i < Stage1.GetLength(0); i++)
            {
                for (int j = 0; j < Stage1.GetLength(1); j++)
                {
                    Stage1_Graphic[k, j] = Stage1[i, j];
                }
                k++;
            }

            //4번째마다 가로줄 그래픽 초기화
            Count = 0;

            Invalidate();
        }
        public Form1()
        {
            InitializeComponent();
            Represher_();
        }

        private void Form1_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void ticktock_Tick(object sender, EventArgs e)
        {
            
        }

        private void Represher_Tick(object sender, EventArgs e)
        {
            Represher_();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle();
            int Box_Width = 40, Box_Height = Box_Width;
            int Box_X = Box_Width + Box_Width/2, Box_Y = Box_Height + Box_Height/2;

            //4번째 블록마다 가로줄
            e.Graphics.DrawLine(Pens.Black, Box_X, Box_Y * Count, Box_X + 100, Box_Y * Count);
            e.Graphics.DrawLine(Pens.Black, Box_X, (Box_Y * 4) + (Box_Y * Count), Box_X + 100, (Box_Y * 4) + (Box_Y * Count));
            Count++;
            if (Count == 4) Count = 0;

            for (int i = 0; i < Stage1_Graphic.GetLength(0); i++)
            {
                for (int j = 0; j < Stage1_Graphic.GetLength(1); j++) 
                {
                    if(Stage1_Graphic[i,j] == 1)
                    {
                        //e.Graphics.DrawString("" + Stage1_Graphic[i, j], Font, Brushes.Black, j * 10, i * 10);
                        rect.X = Box_X * j;
                        rect.Y = Box_Y * i;
                        rect.Width = Box_Width;
                        rect.Height = Box_Height;

                        e.Graphics.DrawRectangle(Pens.Black, rect);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //int[] KEY = new int[] { 0, 0, 0 };

            if (e.KeyCode == Keys.Left) KEY[0] = 1 ;
            if (e.KeyCode == Keys.Right) KEY[2] = 1;
            if (e.KeyCode == Keys.Down) KEY[1] = 1;
            if (e.KeyCode == Keys.Up) KEY[1] = 1;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //최 하단 배열과 키 값 배열이 일치하는지
            if (Stage1_Graphic[7, 0] == KEY[0] &&
                Stage1_Graphic[7, 1] == KEY[1] &&
                Stage1_Graphic[7, 2] == KEY[2])
            {
                Shift();
            }

            //받은 키 값 초기화
            KEY[0] = 0;
            KEY[1] = 0;
            KEY[2] = 0;
        }
    }
}