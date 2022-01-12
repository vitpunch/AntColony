using System;
using System.Windows;
using AntColony.Drawers;

namespace AntColony;

public static class Configuration
{
    public static StartWindow mainWindow;
    public static int InitScale { get; } = 10;//масштаб главного окна. 1 cell = 50*50
    public static int WorkerPrice { get; } = 10;
    static readonly Random _random=new Random();
    public static int FieldSizeX { get; } = 440;
    public static int FieldSizeY { get; } = 160;
    public static int AntMinHike { get; } = 15;
    public static int AntMaxHike { get; } = 150;
    public static int WorkerInitHealth { get; } = 50;
    public static int WaitBeforeTurn { get; } = 5;
    public readonly static IDrawer drawer = new WpfDrawer();

    public static int Rand(int max)
    {
        return _random.Next(max);
    }
}