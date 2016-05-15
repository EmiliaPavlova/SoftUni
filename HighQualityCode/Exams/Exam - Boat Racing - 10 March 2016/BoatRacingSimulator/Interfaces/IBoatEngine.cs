namespace BoatRacingSimulator.Interfaces
{
    public interface IBoatEngine : IModelable
    {
        int HorsePower { get; }

        int Displacement { get; }

        int Output();
    }
}