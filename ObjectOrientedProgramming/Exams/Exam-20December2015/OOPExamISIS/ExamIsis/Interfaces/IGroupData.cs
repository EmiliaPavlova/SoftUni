namespace ExamIsis.Interfaces
{
    using System.Collections.Generic;

    public interface IGroupData
    {
        IEnumerable<IGroup> Groups { get; }

        void AddGroup(IGroup group);
        //void PrintStatus();
    }
}
