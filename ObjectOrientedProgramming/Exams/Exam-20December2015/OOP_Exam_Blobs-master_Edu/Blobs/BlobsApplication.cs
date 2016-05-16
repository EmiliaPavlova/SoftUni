namespace Blobs
{
    using System.Collections.Generic;
    using Core;
    using Core.Factories;
    using Interfaces;
    using IO;

    public class BlobsApplication
    {
        static void Main()
        {
            var appEngine = new Engine(
                new BlobFactory(),
                new AttackFactory(),
                new BehaviorFactory(),   
                new ConsoleInputReader(), 
                new ConsoleOutputWriter(), 
                new BlobData(new List<IBlob>()));

            appEngine.Run();
        }
    }
}
