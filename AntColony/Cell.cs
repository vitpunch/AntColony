using AntColony.Animals;
using static AntColony.Configuration;

namespace AntColony;

public class Cell
{
    public IAnimal? Animal { get; set; } = null;
    public int FoodSmell { get; set; }
    public int DangerSmell { get; set; }
    public Decor? Decor { get; set; } = new Decor();
    public int Eat { get; set; }
    public bool IsBusy { get; set; }

    public void Go()
    {
    }

    public bool AbilityToMove()
    {
        return !IsBusy;
    }
}