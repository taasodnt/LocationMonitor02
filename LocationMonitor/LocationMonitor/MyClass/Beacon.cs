using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMonitor.MyClass
{
    class Beacon
    {
        int floor;
        Point location;
        Color color;

        public Beacon(int floor, Point location, Color color)
        {
            this.floor = floor;
            this.location = location;
            this.color = color;
        }
    }
}
