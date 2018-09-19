using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17SeptPacman.Classes
{
    class Floor : Entity, IEntity
    {
        public Floor(Point location) : base(location, Color.Beige, 50)
        {
        }

        public bool CanEat(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool CanPassThrough(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Draw(Graphics g)
        {
            Brush myBrush = new SolidBrush(color);
            Rectangle sprite = new Rectangle(location.X, location.Y, size, size);
            g.FillRectangle(myBrush, sprite);
            myBrush.Dispose();
        }

    }
}
