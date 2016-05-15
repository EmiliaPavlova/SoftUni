namespace BoatRacingSimulator.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T item);

        T GetItem(string model);
    }
}
