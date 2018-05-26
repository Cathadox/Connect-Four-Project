using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    public abstract class Player
    {
        public int Chips;
        public string Name { get; set; }
        public int Points { get; set; }
        public List<int> Score { get; set; }
        public Player(string Name, int Chips)
        {
            Points = 0;
            Score = new List<int>();
            this.Name = Name;
            this.Chips = Chips;
            
        }
        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Points);
        }
        public bool CheckWin(int [][] board)
        {
            bool win;
            win = CheckDiagonal(board);
            return win;
        }
        public bool CheckDiagonal(int [][] board)
        {
            for (int i = 0; i < board.Length - 3; i++)
                for (int j = 0; j < board[i].Length - 3; j++)
                    if ((board[i][j] == board[i + 1][j + 1]) == (board[i + 2][j + 2] == board[i + 3][j + 3]))
                        if(board[i][j]==Chips)
                        return true;
            //for (int i = board.Length - 1; i >= 5; i--)
            //    for (int j = board[i].Length; j >= 5; j--)
            //        if ((board[i][j] == board[i - 1][j - 1]) == (board[i - 2][j - 2] == board[i - 3][j - 3]))
            //            if (board[i][j] == Chips)
            //                return true;
            return false;

        }
    }
}
