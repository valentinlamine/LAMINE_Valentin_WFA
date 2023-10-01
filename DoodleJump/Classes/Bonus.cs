using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Bonus
    {
        public Physics physics; // Physics properties of the bonus
        public Image sprite;   // Image representing the bonus
        public int type;       // Type of the bonus

        public Bonus(PointF pos, int type)
        {
            // Constructor for creating a bonus with a specific type and position
            switch (type)
            {
                case 1:
                    sprite = Properties.Resources.spring; // Load the sprite for bonus type 1 (spring)
                    physics = new Physics(pos, new Size(15, 15)); // Initialize physics properties
                    break;
                case 2:
                    sprite = Properties.Resources.jetpack; // Load the sprite for bonus type 2 (jetpack)
                    physics = new Physics(pos, new Size(30, 30)); // Initialize physics properties
                    break;
            }
            this.type = type; // Set the type of the bonus
        }

        public void DrawSprite(Graphics g)
        {
            // Draw the bonus sprite on the screen
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }
    }
}
