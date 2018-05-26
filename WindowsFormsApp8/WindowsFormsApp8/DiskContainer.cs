using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp8
{
    [Serializable]
    public class DiskContainer
    {
        public List<RedDisk> Red;
        public List<YellowDisk> Yellow;
        private float Width;
        private float Height;
        private float CenterX;
        private float CenterY;
        public float RedX { get; set; }
        public float RedY { get; set; }
        public float YellowX { get; set; }
        public float YellowY { get; set; }
        public DiskContainer(float Width)
        {
            CenterX = Width - 400;
            CenterY = Width / 2 - 50;
            this.Width = 300;
            this.Height = 150;
            RedX = CenterX + 75;
            RedY = CenterY + 75;
            YellowX = CenterX + 225;
            YellowY = RedY;
            Red = new List<RedDisk>();
            Yellow = new List<YellowDisk>();
            for(int i=0; i<21; i++)
            {
                RedDisk R = new RedDisk(RedX, RedY);
                YellowDisk Y = new YellowDisk(YellowX, YellowY);
                Red.Add(R);
                Yellow.Add(Y);
            }
           
        }
        public void Draw(Graphics g)
        {
            SolidBrush ContainerBrush = new SolidBrush(Color.LightGreen);
            g.FillRectangle(ContainerBrush, CenterX, CenterY, Width, Height);
            ContainerBrush.Dispose();
            foreach (RedDisk r in Red)
                r.Draw(g);
            foreach (YellowDisk y in Yellow)
                y.Draw(g);
        }
        
    }
}
