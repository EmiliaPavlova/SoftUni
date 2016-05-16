namespace Pr2.Animals.Animals
{
    public class Tomcat : Cat, ISoundProducible
    {
        public Tomcat(string name, int age) 
            : base(name, age, Animals.Gender.male)
        {
        }

        public override string ProduceSound()
        {
            return "Miau miau";
        }
    }
}
