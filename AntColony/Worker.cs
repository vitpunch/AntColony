using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntColony
{
    internal class Worker :Ant
    {
        static readonly Random _random = new();
        private int _hikeLength;
        public double X { get; set; }
        public double Y { get; set; }
        public double Direction { get; set; }


        public Worker(int x, int y)
        {
            X = x; Y = y;
            Direction =  _random.Next(360);
            _hikeLength = _random.Next(500);

        }
        public void Go()
        {
            X = X + (Math.Cos(Direction/360 * 2 * Math.PI));
            Y = Y -  (Math.Sin(Direction/360 * 2 * Math.PI));
            if (--_hikeLength < 0)
            {
                _hikeLength = _random.Next(500);
                Direction = _random.Next(360);
            }
        }
    }
}
