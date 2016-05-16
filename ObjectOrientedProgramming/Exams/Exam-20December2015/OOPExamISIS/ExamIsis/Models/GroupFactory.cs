namespace ExamIsis.Models
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces;

    internal class GroupFactory : IGroupFactory
    {
        public IGroup CreateGroup(string name, int health, int damage, string warEffect, string attackType)
        {
            var group = new Group(name, health, damage, warEffect, attackType);
            return group;
        }
    }
}