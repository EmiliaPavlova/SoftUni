using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem
{
    public class Student : Person
    {
        private string studentNumber;
        private double averageGrade;

        public Student(string firstName, string lastName, int age, string studentNumber, double averageGrade)
            : base(firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }

        public string StudentNumber
        {
            get { return this.studentNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The student number cannot be empty");
                }
                this.studentNumber = value;
            }
        }

        public double AverageGrade
        {
            get { return this.averageGrade; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The average grade cannot be a negative number");
                }
                this.averageGrade = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                string.Format("\nRole: {0}\nStudent number: {1}\nAverage grade: {2}\n", this.GetType().Name, this.StudentNumber, this.AverageGrade);
        }
    }
}
