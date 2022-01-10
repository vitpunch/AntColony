using AntColony.Animals;

namespace AntColony;

public class Cell
{
    public IAnimal? Animal { get; set; } = null;
    public int FoodSmell { get; set; }
    public int DangerSmell { get; set; }
    public Decor? Decor { get; set; } = new Decor();
    public int Eat { get; set; }

    public void Go()
    {
        if (Animal!=null)
            Animal.Go();
    }

    public bool AbilityToMove()
    {
        return (Animal == null);
    }
}