
using BigMani.UI;
using BigMani.Wokr;

namespace BigMani
{

    public class Program
    {
        public static void Main()
        {
            var engine = new Engine(new ConsoleUserInterface());
            engine.Run();
        }
    }
}
