using AntColony.Animals;

namespace AntColony;

public class Cell
{
    public IAnimal? Animal { get; set; } = null;
    public int SmellFood { get; set; }
    public int SmellDanger { get; set; }
    public Decor? Decor { get; set; } = new Decor();
    public int Eat { get; set; }

    public void Go(){}
}