using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp8
{
    [Serializable]
    public class YellowDisk
    {
        static private readonly int Radius = 50;

        private Color Color = Color.Yellow;
        public float X { get; set; }
        public float Y { get; set; }
        public YellowDisk(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public void Draw(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color);
            g.FillEllipse(b, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            b.Dispose();
        }
    }
}
