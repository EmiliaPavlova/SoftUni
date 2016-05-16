namespace Blobs.IO
{
    using System;
    using Interfaces;

    public class ConsoleOutputWriter : IOutputWriter
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}
