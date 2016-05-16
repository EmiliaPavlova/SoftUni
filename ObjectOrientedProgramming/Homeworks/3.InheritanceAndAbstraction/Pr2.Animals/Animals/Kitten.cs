namespace Pr2.Animals.Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age, Animals.Gender.female)
        {
        }

        public override string ProduceSound()
        {
            return "Murrrrrrrrrr";
        }
    }
}
