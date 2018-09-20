using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _17SeptPacman.Classes
{
    public static class EntityFactory
    {
        public static List<Entity> entities = new List<Entity>();
         
        public static void SetWall(Point loc) { entities.Add(new Wall(loc)); }
                           
        public static void SetFloor(Point loc) { entities.Add(new Floor(loc)); }
                           
        public static void SetFruit(Point loc) { entities.Add(new Fruit(loc)); }
                           
        public static void SetPlayer(Point loc) { entities.Add(new Player(loc)); }
                           
        public static void SetSuperEnemy(Point loc) { entities.Add(new SuperEnemy(loc)); }

        public static void SetRegularEnemy(Point loc) { entities.Add(new RegularEnemy(loc)); }

        public static void ReplaceByFloor(Entity entity) { entities[entities.IndexOf(entity)] = new Floor(entity.location); }

        public static void Init() { entities = new List<Entity>(); }

        public static void LoadLevel(int size, int[,] level)
        {
            //if (level)
            //{
            //
            //}
            Init();
            Point gridLoc = new Point();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    gridLoc = new Point(j * size / 10, i * size / 10);
                    switch (level[i, j])
                    {
                        case 0:
                            SetWall(gridLoc);
                            break;
                        case 1:
                            SetFloor(gridLoc);
                            break;
                        case 2:
                            SetFloor(gridLoc);
                            SetPlayer(gridLoc);
                            break;
                        case 3:
                            SetFruit(gridLoc);
                            break;
                        case 4:
                            SetFloor(gridLoc);
                            SetFruit(gridLoc);
                            SetRegularEnemy(gridLoc);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

    }
}
