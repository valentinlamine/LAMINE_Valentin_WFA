using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Player
    {
        public Physics physics; // Physics component for player
        public Image sprite; // Image representing the player
        public bool IsRight; // Flag to indicate player direction (right or left)
        public bool IsShooting; // Flag to indicate if the player is shooting

        public Player()
        {
            // Initialize player sprite and physics properties
            sprite = Properties.Resources.man2;
            physics = new Physics(new PointF(100, 350), new Size(40, 40));
        }

        public void DrawSprite(Graphics g)
        {
            // Draw the player sprite on the screen
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }

        public void ChangeSprite()
        {
            // Change the player sprite based on the direction and bonuses
            if (physics.usedBonus)
            {
                if (IsRight)
                {
                    sprite = Properties.Resources.man_jetpack_right; // Right-facing sprite with jetpack
                }
                else
                {
                    sprite = Properties.Resources.man_jetpack; // Left-facing sprite with jetpack
                }
            }
            else
            {
                if (IsRight)
                {
                    sprite = Properties.Resources.man2_right; // Right-facing default sprite
                }
                else
                {
                    sprite = Properties.Resources.man2; // Left-facing default sprite
                }
            }
        }

        public void TeleportIfOutOfBounds(int screenWidth)
        {
            // Teleport the player to the opposite side if they go out of bounds
            if (physics.transform.position.X < 0)
            {
                physics.transform.position.X = screenWidth - physics.transform.size.Width;
            }
            else if (physics.transform.position.X + physics.transform.size.Width > screenWidth)
            {
                physics.transform.position.X = 0;
            }
        }

        public bool IsInJetpack()
        {
            // Check if the player is using the jetpack bonus
            return physics.usedBonus;
        }
    }
}
