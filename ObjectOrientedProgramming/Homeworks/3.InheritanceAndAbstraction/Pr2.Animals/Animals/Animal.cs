using System;

namespace Pr2.Animals.Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private Gender gender;

        protected Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name cannot be null, empty or whitespace");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Age cannot be negative number.");
                }
                this.age = value;
            }
        }

        public Gender Gender { get; set; }

        public abstract string ProduceSound();
    }
}
