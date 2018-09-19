using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17SeptPacman.Classes
{
    class SuperEnemy : Enemy
    {
        public SuperEnemy(Point location) : base(location, Color.Red, 50)
        {
        }

        public override void Draw(Graphics g)
        {
            Brush myBrush = new SolidBrush(color);
            Rectangle sprite = new Rectangle(location.X, location.Y, size, size);
            g.FillRectangle(myBrush, sprite);
            myBrush.Dispose();
        }
    }
}
