using System.Collections.Generic;
using System.Drawing;
using AntColony.Animals;
using AntColony.Animals.Ants;
using static AntColony.Configuration;

namespace AntColony;

public class AntHill
{
    public int Eat { get; set; } = 900000;
    public Point Center;
    static List<IAnt> Ants =new ();

    public AntHill(int centerX, int centerY)
    {
        Center = new Point(centerX, centerY);
    }
    public IAnimal GetNewAnt()
    {
        return new Worker(Center.X, Center.Y);
    }
}