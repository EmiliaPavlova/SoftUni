namespace InheritanceAndPolymorphism.Course
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public abstract class Course : ICourse
    {
        private string courseName;
        private string teacherName;
        private readonly IList<string> students;

        protected Course(string courseName, string teacherName)
        {
            this.CourseName = courseName;
            this.TeacherName = teacherName;
            this.students = new List<string>();
        }

        public string CourseName
        {
            get { return this.courseName; }
            private set {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.CourseName), "Course name can not be null or empty!");
                }

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get { return this.teacherName; }
            set {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.TeacherName), "Teacher name can not be null or empty!");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get { return this.students; }
        }

        public void AddStudent(string studentName)
        {
            if (String.IsNullOrWhiteSpace(studentName))
            {
                throw new ArgumentNullException(nameof(studentName), "Students name can not be null or empty string");
            }

            this.students.Add(studentName);
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{Empty Students list}";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder courseResult = new StringBuilder();
            courseResult.AppendFormat("{0}: {{ Name = {1}; ", this.GetType().Name, this.CourseName);
            courseResult.AppendFormat("Teacher = {0}; ", this.TeacherName);
            courseResult.AppendFormat("Students = {0} }}", this.GetStudentsAsString());

            return courseResult.ToString();
        }
    }
}