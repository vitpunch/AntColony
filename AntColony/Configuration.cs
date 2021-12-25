using System;
using AntColony.Drawers;

namespace AntColony;

public static class Configuration
{
    public static int WorkerPrice { get; } = 10;
    static readonly Random _random=new Random();
    public static int FieldSizeX { get; } = 1000;
    public static int FieldSizeY { get; } = 1000;
    public static int AntMaxHike { get; } = 100;
    public static int WorkerInitHealth { get; } = 50;
    public readonly static IDrawer drawer = new WpfDrawer();

    public static int Rand(int max)
    {
        return _random.Next(max);
    }
}