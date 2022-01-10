using System;
using System.Drawing;
using static AntColony.Configuration;

namespace AntColony.Animals.Ants
{
    public class Worker :IAnt
    {
        private bool isMoved = false;
        public int Health { get; } = WorkerInitHealth;
        private int _hikeLength;
        private double _x, _y;
        public int X { get { return (int)_x; } }
        public int Y { get { return (int)_y; } }
        public int Direction { get; set; }
        public double XForDrawer { get { return _x; } }
        public double YForDrawer { get { return _y; } }

        public Worker(int x, int y)
        {
            _x = x; _y = y;
            Direction =  Rand(360);
            _hikeLength = Rand(AntMaxHike-AntMinHike)+AntMinHike;
        }
        public void Go()
        {
            if (isMoved)
            {
                isMoved = false;
                return;
            }
            Point _nextPoint = GetNextPoint();
            if (!(_nextPoint != new Point(X, Y) && Field.AbilityToMove(_nextPoint)))
            {
                _hikeLength = Rand(AntMaxHike-AntMinHike)+AntMinHike;
                Direction = Rand(360);
                return;
            }

            isMoved = true;
            Field.MoveAnimal(new Point(X, Y), _nextPoint);
            _x = _x + Trigonometria.Cos(Direction);
            _y = _y + Trigonometria.Sin(Direction);
            if (--_hikeLength < 0)
            {
                _hikeLength = Rand(AntMaxHike); 
                Direction = Rand(360);
            }
        }

        private Point GetNextPoint()
        {
            return new Point(
                (int)(_x + Trigonometria.Cos(Direction)),
                (int)(_y + Trigonometria.Sin(Direction))
                );
        }
    }
}
