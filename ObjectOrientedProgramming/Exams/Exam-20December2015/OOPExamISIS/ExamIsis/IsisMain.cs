namespace ExamIsis
{
    using IO;
    using Models;

    public class IsisMain
    {
        static void Main(string[] args)
        {
            var groupFactory = new GroupFactory();
            var data = new GroupData();
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var engine = new Engine(groupFactory, data, reader, writer);
            engine.Run();
        }
    }
}
