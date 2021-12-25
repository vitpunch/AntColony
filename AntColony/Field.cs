using System;
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
        Configuration.drawer.DrawAllAnts();
    }

    public static void SetAntHill()
    {
        //установка муравейника на поле
        AntHill.X = Rand(FieldSizeX-11)+5;
        AntHill.Y = Rand(FieldSizeY-11)+5;
        for (int i = -5; i < 6; i++)
        {
            for (int j = -5; j < 6; j++)
            {
                _cells[j+AntHill.X, i+AntHill.Y].Decor.TypeOfDecor = Decor.TypeDecor.anthill;
            }
        }
    }
}