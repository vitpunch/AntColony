namespace AntColony;

public class Decor
{
    public TypeDecor TypeOfDecor {get; set; }

public enum TypeDecor
    {
        grass,
        stone,
        water,
        tree,
        anthill
    }
}