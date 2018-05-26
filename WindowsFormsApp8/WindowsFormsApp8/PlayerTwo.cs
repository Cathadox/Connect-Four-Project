using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    [Serializable]
    public class PlayerTwo : Player
    {
        public int YellowChips { get; set; }
        public PlayerTwo(string Name) : base(Name, 2)
        {
            YellowChips = 2;
        }

    }
}
