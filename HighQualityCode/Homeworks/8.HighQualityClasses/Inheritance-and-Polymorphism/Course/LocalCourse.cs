namespace InheritanceAndPolymorphism.Course
{
    using System;
    using System.Text;

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string courseName, string teacherName, string lab) 
            : base(courseName, teacherName)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get { return this.lab; }
            set {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(lab), "Lab name can not be null or empty space");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder localCourseResult = new StringBuilder(base.ToString());
            localCourseResult.Length -= 2;
            localCourseResult.AppendFormat("; Lab = {0} }}", this.Lab);

            return localCourseResult.ToString();
        }
    }
}
