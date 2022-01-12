using System;
using System.Collections.Generic;
using System.Drawing;
using AntColony.Animals;
using AntColony.Animals.Ants;
using static AntColony.Configuration;
namespace AntColony;

//Поле игры
public static class Field
{
    private static Cell[,] _cells = new Cell[FieldSizeX, FieldSizeY];
    private static List<AntHill> _antHills = new List<AntHill>();
    private static List<IAnimal> _animals = new List<IAnimal>();

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
        mainWindow.animakCount = 0;
        foreach (var animal in _animals)
        {
            animal.Go();
        }
        drawer.DrawAllAnts(_animals);   
        mainWindow.AnimalCount.Content = mainWindow.animakCount.ToString();
    }

    public static void SetAntHill()
    {
        _antHills.Add(new AntHill(FieldSizeX -20, FieldSizeY -20));
    }

    public static void AntBorn()
    {
        _animals.Add(_antHills[Rand(_antHills.Count)].GetNewAnt());
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
        _cells[nextPoint.X, nextPoint.Y].IsBusy = true;
        _cells[firstPoint.X, firstPoint.Y].IsBusy = false;
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

    public static void SetNewDirectionForCollidedAnts(Point firstAnt, Point secondAnt)
    {
        _cells[firstAnt.X,firstAnt.Y].Animal.SetNewDirection();
        if (PermisCoordinates(secondAnt))
        {
            if(secondAnt.Y>firstAnt.Y||(secondAnt.Y==firstAnt.Y && secondAnt.X>firstAnt.X))
                _cells[secondAnt.X, secondAnt.Y].Animal.SetNewDirection();
        }
    }
}