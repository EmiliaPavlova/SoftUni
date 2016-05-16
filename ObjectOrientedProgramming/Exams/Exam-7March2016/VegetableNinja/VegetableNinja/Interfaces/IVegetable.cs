namespace VegetableNinja.Interfaces
{
    public interface IVegetable : IUpdateable
    {
        char Name { get; }

        int PowerEffect { get; }

        int StaminsEffect { get; }

        bool isTaken { get; }

        bool isGrown { get; }

        void Regrow();
    }
}