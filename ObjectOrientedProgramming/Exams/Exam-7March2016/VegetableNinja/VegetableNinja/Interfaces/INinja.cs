namespace VegetableNinja.Interfaces
{
    public interface INinja : IUpdateable
    {
        string Name { get; }

        int Power { get; }

        int Stamina { get; }

        int PositionX { get; set; }

        int PositionY { get; set; }

        void ApplyVegetableEffect(IVegetable vegetable);
    }
}