using System;
using AntColony.Drawers;

namespace AntColony;

public static class Configuration
{
    public static readonly Random _random=new Random();
    public static int FieldSizeX { get; } = 500;
    public static int FieldSizeY { get; } = 500;
    public static int WorkerInitHealth { get; } = 50;
    public readonly static IDrawer drawer = new WpfDrawer();

    public static int Rand(int max)
    {
        return _random.Next(max);
    }
}