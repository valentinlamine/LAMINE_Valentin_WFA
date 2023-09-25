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
        Image sprite;
        public Transform transform;
        public int SizeX;
        public int SizeY;
        public bool isTouchedByPlayer;

        public Platform(PointF pos)
        {
            sprite = Properties.Resources.platform;
            SizeX = 60;
            SizeY = 12;
            transform = new Transform(pos, new Size(SizeX, SizeY));
            isTouchedByPlayer = false;

        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);
        }
    }
}
