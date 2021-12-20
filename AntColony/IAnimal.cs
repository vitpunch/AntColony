using System.Dynamic;

namespace AntColony;


public interface IAnimal
{
    public int Health { get; }
    public void Go();
}