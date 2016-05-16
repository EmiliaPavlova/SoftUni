using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem
{
    public class Trainer : Person
    {
        public Trainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }

        public void CreateCourse(string courseName)
        {
            Console.WriteLine("Created course {0}", courseName);
        }

        public override string ToString()
        {
            string result = base.ToString() + string.Format("\nRole: {0}\n", this.GetType().Name);
            return result;
        }
    }
}
