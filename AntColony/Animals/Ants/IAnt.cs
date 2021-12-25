namespace AntColony.Animals.Ants
{
    internal interface IAnt : IAnimal
    {
        public int X { get;  }
        public int Y { get;  }
        int Direction { get; set; }
    }
}
