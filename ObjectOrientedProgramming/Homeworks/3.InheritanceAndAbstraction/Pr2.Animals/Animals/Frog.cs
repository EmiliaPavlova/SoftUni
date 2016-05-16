namespace Pr2.Animals.Animals
{
    public class Frog : Animal, ISoundProducible
    {
        public Frog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Kvak-kvak";
        }
    }
}
