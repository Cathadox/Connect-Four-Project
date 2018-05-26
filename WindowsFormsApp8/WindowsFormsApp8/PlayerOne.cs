using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    [Serializable]
    public class PlayerOne : Player
    {
        public int RedChips { get; set; }
       
        public PlayerOne(string Name) : base(Name, 1)
        {
            RedChips = 1;
        }


       
    }
}
