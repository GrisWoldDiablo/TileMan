using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17SeptPacman.Classes
{
    class Fruit : Entity, IEntity
    {
        public Fruit(Point location) : base(location, Color.Green, 50)
        {
        }

        bool IEntity.CanEat(IEntity entity)
        {
            throw new NotImplementedException();
        }

        bool IEntity.CanPassThrough(IEntity entity)
        {
            throw new NotImplementedException();
        }

        void IEntity.Draw(Graphics g)
        {
            Brush myBrush = new SolidBrush(color);
            Rectangle sprite = new Rectangle(location.X, location.Y, size, size);
            g.FillRectangle(myBrush, sprite);
            myBrush.Dispose();
        }
    }
}
