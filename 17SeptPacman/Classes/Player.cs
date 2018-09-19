using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _17SeptPacman.Enum;

namespace _17SeptPacman.Classes
{
    class Player : Entity, IEntity
    {
        private bool boosted;

        public Player(Point location) : base(location, Color.Blue, 50)
        {
        }

        public bool CanEat(IEntity entity)
        {
            return (entity is Enemy && boosted) || entity is Fruit;
        }

        public bool CanPassThrough(IEntity entity)
        {
            return !(entity is Wall);
        }

        public void Move(int maxX, int maxY, Direction dir, List<Entity> entities)
        {
            Entity entity = null;
            switch (dir)
            {
                case Direction.UP:
                    entity = entities.Find(x => x.location == new Point(location.X, location.Y - size));
                    if (entity == null)
                    {
                        break;
                    }
                    if (CanPassThrough((IEntity)entity))
                    {
                        location.Y -= size;
                    }

                    break;
                case Direction.DOWN:
                    entity = entities.Find(x => x.location == new Point(location.X, location.Y + size));
                    if (entity == null)
                    {
                        break;
                    }
                    if (CanPassThrough((IEntity)entity))
                    {
                        location.Y += size;
                    }

                    break;
                case Direction.LEFT:
                    entity = entities.Find(x => x.location == new Point(location.X - size, location.Y));
                    if (entity == null)
                    {
                        break;
                    }
                    if (CanPassThrough((IEntity)entity))
                    {
                        location.X -= size;
                    }

                    break;
                case Direction.RIGHT:
                    entity = entities.Find(x => x.location == new Point(location.X + size, location.Y));
                    if (entity == null)
                    {
                        break;
                    }
                    if (CanPassThrough((IEntity)entity))
                    {
                        location.X += size;
                    }

                    break;
                default:
                    break;
            }
            if (entity == null)
            {
                return;
            }
            if (CanEat((IEntity)entity))
            {
                EntityFactory.ReplaceByFloor(entity);
            }
        }

        
        public void Draw(Graphics g)
        {
            Brush myBrush = new SolidBrush(color);
            Rectangle sprite = new Rectangle(location.X, location.Y, size, size);
            g.FillRectangle(myBrush, sprite);
            myBrush.Dispose();
        }

        public bool Boosted { get => boosted; set => boosted = value; }
    }
}
