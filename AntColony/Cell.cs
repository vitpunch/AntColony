namespace AntColony;

public class Cell
{
    public IAnimal? Animal { get; set; }
    public int SmellFood { get; set; }
    public int SmellDanger { get; set; }
    public Decor? decor { get; set; } = null;
    
}