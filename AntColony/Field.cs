using System;
using System.Drawing;
using AntColony.Animals;
using AntColony.Animals.Ants;
using static AntColony.Configuration;
namespace AntColony;

//Поле игры
public static class Field
{
    private static Cell[,] _cells = new Cell[FieldSizeX, FieldSizeY];

    static Field()
    {
        for (int i = 0; i < FieldSizeY; i++)
        {
            for (int j = 0; j < FieldSizeX; j++)
            {
                _cells[j, i] = new();
            }
        }
    }
    public static void Go()
    {
        for (int i = 0; i < FieldSizeY; i++)
        {
            for (int j = 0; j < FieldSizeX; j++)
            {
                    _cells[j,i].Go();
            }
        }
        drawer.DrawAllAnts(_cells);
    }

    public static void SetAntHill()
    {
        //установка муравейника на поле
        AntHill.X = FieldSizeX / 2;//Rand(FieldSizeX-11)+5;
        AntHill.Y = FieldSizeY / 2;//Rand(FieldSizeY-11)+5;
        for (int i = -5; i < 6; i++)
        {
            for (int j = -5; j < 6; j++)
            {
                _cells[j+AntHill.X, i+AntHill.Y].Decor.TypeOfDecor = Decor.TypeDecor.anthill;
            }
        }
        drawer.DrawAntHill();
    }

    public static void AntBorn(Worker worker)
    {
        _cells[worker.X, worker.Y].Animal = worker;
    }

    public static bool AbilityToMove(Point nextPoint)
    {
        if(!PermisCoordinates(nextPoint))
            return false;
        return _cells[nextPoint.X, nextPoint.Y].AbilityToMove();
    }

    public static void MoveAnimal(Point firstPoint, Point nextPoint)
    {
        if(!PermisCoordinates(nextPoint))
            return;
        _cells[nextPoint.X, nextPoint.Y].Animal = _cells[firstPoint.X, firstPoint.Y].Animal;
        _cells[firstPoint.X, firstPoint.Y].Animal = null;
    }

    static bool PermisCoordinates(Point point)
    {
        if(point.X<0||
           point.X>=FieldSizeX||
           point.Y<0||
           point.Y>=FieldSizeY)
            return false;
        return true;
    }
}