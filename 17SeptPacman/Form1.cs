using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _17SeptPacman.Classes;
using _17SeptPacman.Enum;

namespace _17SeptPacman
{
    
    public partial class Form1 : Form
    {

        Point gridLoc = new Point();
        int size = 500;
        int[,] level0 = new int[10, 10]
            {
                 {0,0,0,0,0,0,0,0,0,0 },
                 {0,3,3,3,0,0,3,3,3,0 },
                 {0,3,0,3,3,3,3,0,3,0 },
                 {0,3,3,3,0,0,3,3,3,0 },
                 {0,0,3,0,3,3,0,3,0,0 },
                 {0,3,3,3,3,3,3,3,3,0 },
                 {0,3,3,3,0,0,3,3,3,0 },
                 {0,3,0,3,2,3,3,0,3,0 },
                 {0,3,3,3,0,0,3,3,3,0 },
                 {0,0,0,0,0,0,0,0,0,0 }
            };
        Enum.Direction direction;
        private bool onlyOnce = false;

        public Form1()
        {
            InitializeComponent();
            Init();

            ClientSize = new Size(size, size);

        }

        private void Init()
        {
            EntityFactory.Init();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    gridLoc = new Point(j * size / 10, i * size / 10);
                    switch (level0[i, j])
                    {
                        case 0:
                            EntityFactory.SetWall(gridLoc);
                            break;
                        case 1:
                            EntityFactory.SetFloor(gridLoc);
                            break;
                        case 2:
                            EntityFactory.SetFloor(gridLoc);
                            EntityFactory.SetPlayer(gridLoc);
                            break;
                        case 3:
                            EntityFactory.SetFruit(gridLoc);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in EntityFactory.entities)
            {
                ((IEntity)item).Draw(e.Graphics);
            }
            ((IEntity)EntityFactory.entities.Find(x => x is Player)).Draw(e.Graphics);
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
            if (!EntityFactory.entities.Exists(x => x is Fruit) && !onlyOnce)
            {
                onlyOnce = true;
                if (DialogResult.Yes == MessageBox.Show("Reset Board?", "You Win!", MessageBoxButtons.YesNo))
                {
                    Init();
                }
                //MessageBox.Show("You Win!");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Entity player = EntityFactory.entities.Find(x => x is Player);
            if (player is null)
            {
                return;
            }
            if (e.KeyCode == Keys.S)
            {
                ((Player)player).Move(size, size, Direction.DOWN, EntityFactory.entities);
            }
            if (e.KeyCode == Keys.W)
            {
                ((Player)player).Move(size, size, Direction.UP, EntityFactory.entities);
            }
            if (e.KeyCode == Keys.A)
            {
                ((Player)player).Move(size, size, Direction.LEFT, EntityFactory.entities);
            }
            if (e.KeyCode == Keys.D)
            {
                ((Player)player).Move(size, size, Direction.RIGHT, EntityFactory.entities);
            }
        }
    }
}
