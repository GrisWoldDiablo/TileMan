using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void Move(int maxX, int maxY, List<Entity> entities, KeyEventArgs e)
        {
            Entity entity = null;
            Point currentLoc = new Point(location.X,location.Y);
            switch (e.KeyCode)
            {
                case Keys.W:
                    location.Y -= size;
                    //entity = entities.Find(x => x.location == new Point(location.X, location.Y - size));
                    //if (entity == null)
                    //{
                    //    break;
                    //}
                    //if (CanPassThrough((IEntity)entity))
                    //{
                    //    location.Y -= size;
                    //}

                    break;
                case Keys.S:
                    location.Y += size;
                    //entity = entities.Find(x => x.location == new Point(location.X, location.Y + size));
                    //if (entity == null)
                    //{
                    //    break;
                    //}
                    //if (CanPassThrough((IEntity)entity))
                    //{
                    //    location.Y += size;
                    //}

                    break;
                case Keys.A:
                    location.X -= size;
                    //entity = entities.Find(x => x.location == new Point(location.X - size, location.Y));
                    //if (entity == null)
                    //{
                    //    break;
                    //}
                    //if (CanPassThrough((IEntity)entity))
                    //{
                    //    location.X -= size;
                    //}

                    break;
                case Keys.D:
                    location.X += size;
                    //entity = entities.Find(x => x.location == new Point(location.X + size, location.Y));
                    //if (entity == null)
                    //{
                    //    break;
                    //}
                    //if (CanPassThrough((IEntity)entity))
                    //{
                    //    location.X += size;
                    //}

                    break;
                default:
                    break;
            }

            entity = entities.Find(x => x.location == new Point(location.X, location.Y) && !(x is Player));
            if (entity == null)
            {
                location.X = currentLoc.X;
                location.Y = currentLoc.Y;
                return;
            }
            else if (!CanPassThrough((IEntity)entity))
            {
                location.X = currentLoc.X;
                location.Y = currentLoc.Y;
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
