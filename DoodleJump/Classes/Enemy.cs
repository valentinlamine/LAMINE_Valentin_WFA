using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Enemy : Player
    {
        public Enemy(PointF pos, int type)
        {
            // Constructor for creating an enemy with a specific type and position
            switch (type)
            {
                case 1:
                    sprite = Properties.Resources.enemy1r; // Load the sprite for enemy type 1 (right-facing)
                    physics = new Physics(pos, new Size(40, 40)); // Initialize physics properties
                    break;
                case 2:
                    sprite = Properties.Resources.enemy2r; // Load the sprite for enemy type 2 (right-facing)
                    physics = new Physics(pos, new Size(70, 50)); // Initialize physics properties
                    break;
                case 3:
                    sprite = Properties.Resources.enemy3r; // Load the sprite for enemy type 3 (right-facing)
                    physics = new Physics(pos, new Size(70, 60)); // Initialize physics properties
                    break;
            }
        }
    }
}
