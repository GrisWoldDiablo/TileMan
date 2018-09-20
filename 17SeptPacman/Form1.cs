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

namespace _17SeptPacman
{
    
    public partial class Form1 : Form
    {

        private int size = 500;
        private bool onlyOnce = false;

        private int[,] level0 = new int[10, 10]
            {
                 {0,0,0,0,0,0,0,0,0,0 },
                 {0,4,3,3,0,0,3,3,3,0 },
                 {0,3,0,3,3,3,3,0,3,0 },
                 {0,3,3,3,0,0,3,3,3,0 },
                 {0,0,3,0,3,3,0,3,0,0 },
                 {0,3,3,3,3,3,3,3,3,0 },
                 {0,3,3,3,0,0,3,3,3,0 },
                 {0,3,0,3,2,3,3,0,3,0 },
                 {0,3,3,3,0,0,3,3,3,0 },
                 {0,0,0,0,0,0,0,0,0,0 }
            };

        private int[,] level1 = new int[10, 10]
            {
                 {0,0,0,0,0,0,0,0,0,0 },
                 {0,3,3,3,3,3,3,3,3,0 },
                 {0,0,3,0,0,0,0,3,0,0 },
                 {0,3,3,3,3,0,3,3,3,0 },
                 {0,3,0,0,3,3,3,0,0,0 },
                 {0,3,3,3,3,3,3,3,3,0 },
                 {0,3,0,0,3,0,0,0,3,0 },
                 {0,3,0,0,2,3,3,0,3,0 },
                 {0,3,3,3,3,0,3,3,3,0 },
                 {0,0,0,0,0,0,0,0,0,0 }
            };


        public Form1()
        {
            InitializeComponent();
            Init();
            LoadLevel(level0);
            ClientSize = new Size(size, size);

        }

        private void Init()
        {
            EntityFactory.Init();
        }
        private void LoadLevel(int[,] levelToLoad)
        {
            EntityFactory.LoadLevel(size, levelToLoad);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in EntityFactory.entities)
            {
                ((IEntity)item).Draw(e.Graphics);
            }
            Entity player = EntityFactory.entities.Find(x => x is Player);
            if (player != null)
            {
                ((IEntity)player).Draw(e.Graphics); 
            }
            Entity regularEnemy = EntityFactory.entities.Find(x => x is RegularEnemy);
            if (regularEnemy != null)
            {
                ((IEntity)regularEnemy).Draw(e.Graphics); 
            }
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
                    LoadLevel(level1);
                    onlyOnce = false;
                }
            }
            if (!EntityFactory.entities.Exists(x => x is Player) && !onlyOnce)
            {
                onlyOnce = true;
                if (DialogResult.Yes == MessageBox.Show("Reset Board?", "You Loose!", MessageBoxButtons.YesNo))
                {
                    Init();
                    LoadLevel(level0);
                    onlyOnce = false;
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            Entity player = EntityFactory.entities.Find(x => x is Player);
            if (player != null)
            {
                ((Player)player).Move(size, size, EntityFactory.entities, e);
            }
            
        }

        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            Entity regularEnemy = EntityFactory.entities.Find(x => x is RegularEnemy);
            if (regularEnemy != null)
            {
                ((RegularEnemy)regularEnemy).Move(EntityFactory.entities);
            }
        }
    }
}
