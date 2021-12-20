using static AntColony.Configuration;
namespace AntColony;

//Поле игры
public static class Field
{
    private static Cell[,] _cells = new Cell[FieldSizeX, FieldSizeY];

    static Field()
    {
        for (int i = 0; i < FieldSizeY; i++)
        {
            for (int j = 0; j < FieldSizeX; j++)
            {
                _cells[j, i] = new();
            }
        }
    }
}