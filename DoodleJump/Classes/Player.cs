﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Player
    {
        public Physics physics;
        public Image sprite;
        public bool IsRight;
        public bool IsShooting;

        public Player()
        {
            sprite = Properties.Resources.man2;
            physics = new Physics(new PointF(100, 350), new Size(40, 40));
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }

        public void ChangeSprite(bool isMovingRight)
        {
            // Load different sprites based on the direction
            if (isMovingRight)
            {
                sprite = Properties.Resources.man2_right; // Right-facing sprite
            }
            else
            {
                sprite = Properties.Resources.man2; // Left-facing sprite
            }
        }

    }
}
