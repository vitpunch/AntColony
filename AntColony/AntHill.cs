using System;
using System.Collections.Generic;
using static AntColony.Configuration;

namespace AntColony;

public static class AntHill
{
    static List<IAnt> Ants =new ();
    public static int X { get; }

    public static int Y { get; }

    static AntHill()
    {
        X = Rand(FieldSizeX);
        Y = Rand(FieldSizeY);
    }
}