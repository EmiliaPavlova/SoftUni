namespace InheritanceAndPolymorphism.Course
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string courseName, string teacherName, string town) 
            : base(courseName, teacherName)
        {
            this.Town = town;
        }

        public string Town
        {
            get { return this.town; }
            private set {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(town), "Town name can not be null or empty space!");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder offsiteCourseResult = new StringBuilder(base.ToString());
            offsiteCourseResult.Length -= 2;
            offsiteCourseResult.AppendFormat("; Town = {0} }}", this.Town);

            return offsiteCourseResult.ToString();
        }
    }
}
