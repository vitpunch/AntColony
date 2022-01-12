using System.Collections.Generic;
using AntColony.Animals;

namespace AntColony.Drawers;

public interface IDrawer
{
    void DrawAntHill();
    void DrawAllAnts(List<IAnimal> animals);
    void ScaleDown();
    void ScaleUp();
}