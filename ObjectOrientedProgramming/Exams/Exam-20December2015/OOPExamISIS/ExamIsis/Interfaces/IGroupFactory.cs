namespace ExamIsis.Interfaces
{
    public interface IGroupFactory
    {
        IGroup CreateGroup(string name, int health, int damage, string warEffect, string attackType);
    }
}
