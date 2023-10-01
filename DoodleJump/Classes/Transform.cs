using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Transform
    {
        public PointF position; // The position of the object in 2D space
        public Size size;      // The size (dimensions) of the object

        public Transform(PointF position, Size size)
        {
            // Constructor to initialize the position and size of the object
            this.position = position; // Initialize the position with the provided PointF
            this.size = size;         // Initialize the size with the provided Size
        }
    }
}
