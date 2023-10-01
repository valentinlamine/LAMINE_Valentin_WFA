using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Bullet
    {
        public Physics physics; // Physics properties of the bullet
        public Image sprite;   // Image representing the bullet

        public Bullet(PointF pos)
        {
            sprite = Properties.Resources.bullet; // Initialize the bullet sprite
            physics = new Physics(pos, new Size(15, 15)); // Initialize the physics properties of the bullet
        }

        public void MoveUp()
        {
            // Move the bullet upward
            physics.transform.position.Y -= 15;
        }

        public void DrawSprite(Graphics g)
        {
            // Draw the bullet sprite on the screen
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }
    }
}
