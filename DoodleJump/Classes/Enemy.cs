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
        public Enemy(PointF pos)
        {
            sprite = Properties.Resources.enemy1r;
            physics = new Physics(pos, new Size(40, 40));
        }
    }
}
