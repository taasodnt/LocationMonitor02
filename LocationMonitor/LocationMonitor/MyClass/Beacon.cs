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
        private int floor;
        private Point location;
        private string macAddress;

        public Beacon(string mac,int floor, Point location)
        {
            this.floor = floor;
            this.location = location;
            macAddress = mac;
        }

        //for draw
        public Point getLocation()
        {
            return location;
        }

        public int getFloor()
        {
            return floor;
        }
    }
}
