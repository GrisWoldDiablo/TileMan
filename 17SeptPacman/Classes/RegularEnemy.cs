using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17SeptPacman.Classes
{
    class RegularEnemy : Enemy, IEntity
    {
        public RegularEnemy(Point location) : base(location, Color.Yellow, 50)
        {
        }

        public override void Draw(Graphics g)
        {
            Brush myBrush = new SolidBrush(color);
            Rectangle sprite = new Rectangle(location.X, location.Y, size, size);
            g.FillRectangle(myBrush, sprite);
            myBrush.Dispose();
        }

        public void Move(List<Entity> entities)
        {
            Point currentLoc = new Point(location.X, location.Y);
            Entity player = entities.Find(x => x is Player);
            if (player == null) { return; }

            int dirX = (location.X - player.location.X) > 0 ? -size : (location.X - player.location.X) < 0 ? size : 0;
            int dirY = (location.Y - player.location.Y) > 0 ? -size : (location.Y - player.location.Y) < 0 ? size : 0;
            
            Entity entity;
            if (dirX != 0)
            {
                location.X += dirX;
                entity = entities.Find(x => x.location.X == location.X && x.location.Y == location.Y && !(x is RegularEnemy));
                if (!CanPassThrough((IEntity)entity))
                {
                    location.X = currentLoc.X;
                }
            }
            else if (dirY != 0)
            {
                location.Y += dirY;
                entity = entities.Find(x => x.location.X == location.X && x.location.Y == location.Y && !(x is RegularEnemy));
                if (!CanPassThrough((IEntity)entity))
                {
                    location.Y = currentLoc.Y;
                }
            }
            entity = entities.Find(x => x.location.X == location.X && x.location.Y == location.Y && x is Player);
            if (CanEat((IEntity)entity))
            {
                entities.Remove(entity);
            }
            
        }
    }
}
