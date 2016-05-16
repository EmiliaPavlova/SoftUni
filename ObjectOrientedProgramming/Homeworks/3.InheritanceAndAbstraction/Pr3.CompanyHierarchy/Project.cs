using System;
using Pr3.CompanyHierarchy.Interfaces;

namespace Pr3.CompanyHierarchy
{
    public class Project : IProject
    {
        private string projectName;
        private DateTime projectStartDate;
        private string details;
        private State state;

        public Project(string projectName, DateTime projectStartDate, string details, State state)
        {
            this.ProjectName = projectName;
            this.ProjectStartDate = projectStartDate;
            this.Details = details;
            this.State = state;
        }

        public string ProjectName
        {
            get { return this.projectName; }
            set { this.projectName = value; }
        }

        public DateTime ProjectStartDate { get; set; }

        public string Details
        {
            get { return this.details; }
            set { this.details = value; }
        }

        public State State { get; set; }

        public void CloseProject()
        {
            this.State = State.closed;
        }
    }
}
