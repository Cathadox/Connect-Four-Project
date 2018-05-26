using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    [Serializable]
    public class FourMatrix
    {
        private static readonly int Radius = 50;
        private float CenterX;
        private float CenterY;
        private float Width;
        private float Height;
        public int WorldBlocks;
        public int[][] Matrix;
        public enum Difficulty
        {
            EASY,
            NORMAL,
            HARD,
            DEATHAWAITS
        }
        public Difficulty P { get; set; }
        public FourMatrix(float Width)
        {
            CenterX = Width / 2 - 200;
            CenterY = Height / 2;
            this.Height = Width-600;
            this.Width = Width -500;
            P = Difficulty.NORMAL;
            if (P == Difficulty.EASY)
                WorldBlocks = 4;
            if (P == Difficulty.NORMAL)
                WorldBlocks = 6;
            if (P == Difficulty.HARD)
                WorldBlocks = 10;
            if (P == Difficulty.DEATHAWAITS)
                WorldBlocks = 20;
            Matrix = new int[WorldBlocks][];
            for (int i = 0; i < WorldBlocks; i++)
                Matrix[i] = new int[WorldBlocks+1];
            for (int i = 0; i < WorldBlocks; i++)
                for (int j = 0; j < WorldBlocks+1; j++)
                    Matrix[i][j] = 0;
        }
        public void Draw(Graphics g)
        {
            //////////////////Drawing MATRIX FRAME/////////////////////
            SolidBrush MatrixBrush = new SolidBrush(Color.Blue);
            g.FillRectangle(MatrixBrush, CenterX - Width / 2 - 10, CenterY + 60, Width, Height);
            MatrixBrush.Dispose();
            ////////////////Drawing Border Lines - Horizontal//////////////////////
            Pen LinePen = new Pen(Color.Gray, 3);
            for (int i = 0; i < WorldBlocks; i++)
            {
                g.DrawRectangle(LinePen, CenterX - Width / 2 - 10, CenterY + 60+i*Height/6, Width, Height / 6);
            }
            ////////////////Drawing Border Lines - Vertical////////////////////////
            for(int i=0; i<WorldBlocks+1; i++)
            {
                g.DrawRectangle(LinePen, CenterX - Width / 2 - 10 + i*Width/7, CenterY + 60, Width/7, Height);
            }
            ///////////////DRAWING EMPTY POSITIONS//////////////////
            SolidBrush EmptyBrush = new SolidBrush(Color.White);
            //g.FillEllipse(EmptyBrush, Point.X - Radius, Point.Y - Radius, 2 * Radius, 2 * Radius);
            //EmptyBrush.Dispose();
            for (int i = 0; i < Matrix.Length; i++)
            {
                for (int j = 0; j < Matrix[i].Length; j++)
                {
                    if (Matrix[i][j] == 0)
                    {
                        g.FillEllipse(EmptyBrush, j * Radius * 2 - 5 + (Radius)+j*15, i * Radius * 2  +17+ (Radius)+i*17, Radius*2, Radius*2);
                    }
                }
            }
            EmptyBrush.Dispose();
            
        }

        public void DrawMove(Graphics g, Player p, Point M, Label l)
        {
            int column = -1;
            int row = -1;
            column = CheckColumn(M);
            row = CheckRow(column, l);
            if (column != -1 && row!=-1)
            { SolidBrush diskBrush;
                Matrix[row][column] = p.Chips;
                if (p.Chips == 1)
                { diskBrush = new SolidBrush(Color.Red); }
                else
                {
                    diskBrush = new SolidBrush(Color.Yellow);
                }
                g.FillEllipse(diskBrush, column * Radius * 2 - 5 + (Radius) + column * 15, row * Radius * 2 + 17 + (Radius) + row * 17, Radius * 2, Radius * 2);
                diskBrush.Dispose();
            }
        }
        private int CheckColumn(Point P)
        {
                for(int i=0; i<Matrix[0].Length; i++)
                {
                if (P.X >= CenterX - Width / 2 - 10 + i * Width / 7 && P.X <= CenterX - Width / 2 - 10 + i * Width / 7 + Width / 7)
                    if (P.Y >= CenterY + 60 && P.Y <= CenterY + 60 + Height)
                        return i;
                }
            return -1;
        }
        private int CheckRow(int column, Label label)
        {
            for(int i=Matrix.Length-1; i>=0; i--)
            {
               // try
                {
                    label.Text = "";
                    if (Matrix[i][column] == 0)
                        return i;
                }
                //catch(Exception ex)
                //{
                //    label.Text = "You Cannot Put Disks Outside Of The Table, They'll Fallout! " + column.ToString();
                //}
            }
            return -1;
        }


        //public int distanceFromBottom(int column)
        //{
        //    int d = 0;
        //    for (int i = 5; i >= 0; i--)
        //        if (Matrix[i][column] != 0)
        //            d++;
        //        else
        //            break;
        //    return d;
        //}
        //public bool IsWin(int x, int y, int p)
        //{
        //    Dictionary<int, int> xends = new Dictionary<int, int>();
        //    xends.Add(-1, -1);
        //    xends.Add(1, 7);
        //    Dictionary<int, int> yends = new Dictionary<int, int>();
        //    yends.Add(-1, -1);
        //    yends.Add(1, 6);
        //    //int[,] directionPairs = new int[,] { { 1, 0 }, { 0, 1 }, { 1, 1 }, { 2, 1 } };
        //    var tuple1 = new Tuple<int, int>(1, 0);
        //    var tuple2 = new Tuple<int, int>(0, 1);
        //    var tuple3 = new Tuple<int, int>(1, 1);
        //    var tuple4 = new Tuple<int, int>(-1, 1);
        //    var list = new List<Tuple<int, int>>();
        //    list.Add(tuple1);
        //    list.Add(tuple2);
        //    list.Add(tuple3);
        //    list.Add(tuple4);
        //    foreach(Tuple<int,int> tuple in list)
        //    {
        //        int dx = tuple.Item1;
        //        int dy = tuple.Item2;
        //        int firstDirection = 0;
        //        if(dx == 0)
        //        {

        //        }
        //    }




        //}

    }
}
