namespace CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CommandInterpreter
    {
        static void Main(string[] args)
        {
            List<string> collection = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArguments = command.Split(' ');

                switch (commandArguments[0])
                {
                    case "sort":
                        ExecuteSortCommand(commandArguments, collection);
                        break;
                    case "reverse":
                        ExecuteReverseCommand(commandArguments, collection);
                        break;
                    case "rollLeft":
                        ExecuteRollLeftCommand(commandArguments, collection);
                        break;
                    case "rollRight":
                        ExecuteRollRightCommand(commandArguments, collection);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", collection));
        }

        private static void ExecuteReverseCommand(string[] commandArguments, List<string> collection)
        {
            int startIndex = int.Parse(commandArguments[2]);
            int count = int.Parse(commandArguments[4]);

            if (startIndex < 0 || startIndex >= collection.Count || count < 0 || startIndex + count > collection.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            collection.Reverse(startIndex, count);
        }

        private static void ExecuteSortCommand(string[] commandArguments, List<string> collection)
        {
            int startIndex = int.Parse(commandArguments[2]);
            int count = int.Parse(commandArguments[4]);

            if (startIndex < 0 || startIndex >= collection.Count || count < 0 || startIndex + count > collection.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            collection.Sort(startIndex, count, StringComparer.InvariantCulture);
        }

        private static void ExecuteRollRightCommand(string[] commandArguments, List<string> list)
        {
            int count = int.Parse(commandArguments[1]) % list.Count;

            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                string lastElement = list[list.Count - 1];

                list.RemoveAt(list.Count - 1);
                list.Insert(0, lastElement);
            }
        }

        private static void ExecuteRollLeftCommand(string[] commandArguments, List<string> list)
        {
            int count = int.Parse(commandArguments[1]) % list.Count;

            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                string firstElement = list[0];
                list.RemoveAt(0);
                list.Add(firstElement);
            }
        }
    }
}
