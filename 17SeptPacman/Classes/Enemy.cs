using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17SeptPacman.Classes
{
    public abstract class Enemy : Entity, IEntity
    {
        protected Enemy(Point location, Color color, int size) : base(location, color, size)
        {
        }

        public bool CanEat(IEntity entity)
        {
            if (entity is Player)
            {
                return ((Player)entity).Boosted;
            }
            else
            {
                return false;
            }
        }

        public bool CanPassThrough(IEntity entity)
        {
            return !(entity is Wall);
        }

        public abstract void Draw(Graphics graphics);
        
    }
}
