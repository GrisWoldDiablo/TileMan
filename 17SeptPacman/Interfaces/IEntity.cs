using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _17SeptPacman.Classes
{
    public interface IEntity
    {
        bool CanPassThrough(IEntity entity);
        bool CanEat(IEntity entity);
        void Draw(Graphics graphics);
    }
}
