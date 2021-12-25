using System.Collections.Generic;
using AntColony.Animals;
using AntColony.Animals.Ants;
using static AntColony.Configuration;

namespace AntColony;

public static class AntHill
{
    public static int Eat { get; set; }
    public static int X { get; set; }
    public static int Y { get; set; }
    static List<IAnt> Ants =new ();

    public static void WorkerBorn()
    {
        if (Eat >= WorkerPrice)
        {
            Eat -= WorkerPrice;
            Ants.Add(new Worker(X,Y));
        }
    }
}