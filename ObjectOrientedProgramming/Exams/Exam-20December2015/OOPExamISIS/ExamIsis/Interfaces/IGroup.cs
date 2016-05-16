namespace ExamIsis.Interfaces
{
    using Models;

    public interface IGroup : IUpdateable
    {
        string Name { get; }
        int Health { get; }
        int Damage { get; }
    }
}
