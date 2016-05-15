namespace AirConditionerSystem.Interfaces
{
    using Models;

    public interface IAirConditioner
    {
        string Manufacturer { get; }

        string Model { get; }

        Type Type { get; }

        Mark Test();
    }
}