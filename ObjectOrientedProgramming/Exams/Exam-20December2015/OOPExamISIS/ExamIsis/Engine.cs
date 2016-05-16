namespace ExamIsis
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using Interfaces;
    using Group = Models.Group;

    public class Engine : IRunnable
    {
        private readonly IGroupFactory groupFactory;
        private readonly IGroupData data;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public Engine(IGroupFactory groupFactory, IGroupData data, IInputReader reader, IOutputWriter writer)
        {
            this.groupFactory = groupFactory;
            this.data = data;
            this.reader = reader;
            this.writer = writer;
        }

        public virtual void Run()
        {
            while (true)
            {
                string[] inputArgs = this.reader.ReadLine().Split('\r');
                
                //string[] input = Regex.Matches(inputArgs[0], @"[^\.\(\),\s]+").Cast<Match>().Select(m => m.Value).ToArray();
                this.ExecuteCommand(inputArgs);
                this.UpdateStatus();
            }
        }

        private void UpdateStatus()
        {
            foreach (IGroup group in this.data.Groups)
            {
                group.Update();
            }
        }

        private void ExecuteCommand(string[] inputArgs)
        {
            string[] input = inputArgs[0].Split('.');

            if (input[0] == "world")
            {
                switch (input[1])
                {
                    case "status()":
                        this.ExecuteStatusCommand();
                        break;
                    case "akbar()":
                        this.UpdateStatus();
                        break;
                    case "apocalypse()":
                        Environment.Exit(0);
                        break;
                    default:
                        throw new ArgumentException("Unknown command.");
                }
            }
            else if (input[1].Contains("attack"))
            {
                //Todo
            }
            else
            {
                string groupName = input[0];
                string[] part = input[1].Substring(7, input[1].Length - 8).Split(',');
                int health = int.Parse(part[0].Trim());
                int damage = int.Parse(part[1].Trim());
                string warEffect = part[2].Trim();
                var attackType = part[3].Trim();

                IGroup group = this.groupFactory.CreateGroup(groupName, health, damage, warEffect, attackType);
            }

        }

        private void ExecuteStatusCommand()
        {
            this.data.Groups.ToString();
            //this.data.PrintStatus();
            //Console.WriteLine("Hell");
        }
    }
}
