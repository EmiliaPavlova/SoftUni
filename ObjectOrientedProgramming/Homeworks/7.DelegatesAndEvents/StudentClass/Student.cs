using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass
{
    using System.ComponentModel;

    public class Student
    {
        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Name cannot be empty");
                }

                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Name", this.Name, value);
                this.OnPropertyChange(this, args);

                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0 || 150 < value)
                {
                    throw new ArgumentOutOfRangeException("age", "Age should be in the range [0 ... 150].");
                }

                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Age", this.Age, value);
                this.OnPropertyChange(this, args);

                this.age = value;
            }
        }

        private void OnPropertyChange(object student, PropertyChangedEventArgs args)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(student, args);
            }
        }
    }
}
