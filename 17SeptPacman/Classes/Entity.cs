using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17SeptPacman.Classes
{
    public abstract class Entity 
    {
        public Point location;
        protected Color color;
        protected int size;

        protected Entity(Point location, Color color, int size)
        {
            this.location = location;
            this.color = color;
            this.size = size;
        }
    }
}
