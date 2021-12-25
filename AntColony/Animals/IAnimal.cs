namespace AntColony.Animals;


public interface IAnimal
{
    public int Health { get; }
    public void Go();
}