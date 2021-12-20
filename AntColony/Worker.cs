using System;
using static AntColony.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntColony
{
    internal class Worker :IAnt
    {
        public int Health { get; } = WorkerInitHealth;
        static readonly Random _random = new();
        private int _hikeLength;
        private double _x, _y;
        public int X { get { return (int)_x; } }
        public int Y {
            get
            {
                return (int)_y;
            }
        }
        public int Direction { get; set; }


        public Worker(int x, int y)
        {
            _x = x; _y = y;
            Direction =  _random.Next(360);
            _hikeLength = _random.Next(500);
        }
        public void Go()
        {
            _x = _x + Trigonometria.Cos(Direction); //Math.Cos(Direction/360 * 2 * Math.PI));
            _y = _y - Trigonometria.Sin(Direction);//(Math.Sin(Direction/360 * 2 * Math.PI));
            if (--_hikeLength < 0)
            {
                _hikeLength = _random.Next(500);
                Direction = _random.Next(360);
            }
        }
    }
}
