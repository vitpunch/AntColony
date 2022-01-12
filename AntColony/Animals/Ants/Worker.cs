using System;
using System.Drawing;
using static AntColony.Configuration;

namespace AntColony.Animals.Ants
{
    public class Worker :IAnt
    {
        private double _speed;
        public int Health { get; } = WorkerInitHealth;
        private int _hikeLength;
        private double _x, _y;
        private int _waited;
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
            _speed = Rand(80) / 80.0 + 0.2;
        }
        public void Go()
        {
            Point _nextPoint = GetNextPoint();
            Point _currentPoint = new Point(X, Y);
            if (_nextPoint == _currentPoint)
            {
                DoStep();
            }
            else
            {
                if (Field.AbilityToMove(_nextPoint))
                {
                    DoStep();
                    Field.MoveAnimal(_currentPoint,_nextPoint);
                }
                else
                {
                    if (++_waited > WaitBeforeTurn)
                    {
                        SetNewDirection();
                    }
                }
            }
            if (_hikeLength < 0)
            {
                SetNewDirection();
            }
        }
        private Point GetNextPoint()
        {
            return new Point(
                (int)(_x + Trigonometria.Cos(Direction)*_speed),
                (int)(_y + Trigonometria.Sin(Direction)*_speed)
                );
        }
        public void SetNewDirection()
        {
            _waited = 0;
            _hikeLength = Rand(AntMaxHike-AntMinHike)+AntMinHike;
            Direction = Rand(360);
        }
        private void DoStep()
        {
            --_hikeLength;
            _x = _x + Trigonometria.Cos(Direction)*_speed;
            _y = _y + Trigonometria.Sin(Direction)*_speed;
        }
    }
}
