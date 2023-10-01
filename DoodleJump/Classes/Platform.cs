using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Platform
    {
        Image sprite;            // Image representing the platform
        public Transform transform; // Transformation information (position and size) of the platform
        public int SizeX;         // Width of the platform
        public int SizeY;         // Height of the platform
        public bool isTouchedByPlayer; // Flag to indicate if the platform has been touched by the player

        public Platform(PointF pos)
        {
            sprite = Properties.Resources.platform; // Initialize the platform sprite
            SizeX = 60;           // Set the platform width
            SizeY = 12;           // Set the platform height
            transform = new Transform(pos, new Size(SizeX, SizeY)); // Initialize the platform's transform
            isTouchedByPlayer = false; // Initialize the touch state of the platform
        }

        public void DrawSprite(Graphics g)
        {
            // Draw the platform sprite on the screen
            g.DrawImage(sprite, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);
        }
    }
}
