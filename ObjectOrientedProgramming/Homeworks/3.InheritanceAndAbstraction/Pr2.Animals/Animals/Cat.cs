namespace Pr2.Animals.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Meauuuuuuuu!";
        }
    }
}
