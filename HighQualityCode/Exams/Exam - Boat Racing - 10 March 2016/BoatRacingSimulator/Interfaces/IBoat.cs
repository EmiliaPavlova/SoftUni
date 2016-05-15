namespace BoatRacingSimulator.Interfaces
{
    public interface IBoat
    {
        int Weight { get; }

        double CalculateRaceSpeed(IRace race);
    }
}