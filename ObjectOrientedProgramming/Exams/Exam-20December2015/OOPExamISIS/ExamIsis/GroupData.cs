namespace ExamIsis
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Models;

    public class GroupData : IGroupData
    {
        private readonly ICollection<IGroup> groups = new List<IGroup>();

        public IEnumerable<IGroup> Groups => this.groups;

        public void AddGroup(IGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            this.groups.Add(group);
        }

        //public void PrintStatus()
        //{
        //    Console.WriteLine("Group {0}: {1} HP, {2} Damage", this.Groups., group.Health, group.Damage);
        //}
    }
}
