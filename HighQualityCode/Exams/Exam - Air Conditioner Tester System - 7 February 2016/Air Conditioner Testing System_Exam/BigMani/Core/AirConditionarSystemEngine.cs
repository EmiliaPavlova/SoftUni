namespace AirConditionerSystem.Core
{
    using System;
    using Commands;
    using Controllers;
    using Files;
    using Interfaces;

    public class AirConditionarSystemEngine : IEngine
    {
        private CommandExecution ac;
        private ICommand command;
        //private Controller controller;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;


        public AirConditionarSystemEngine(CommandExecution ac, ICommand command, IInputReader reader, IOutputWriter writer)
        {
            this.command = command;
            //this.controller = controller;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string line = this.reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    this.command = new Command(line);
                    this.ac.Execute();
                }
                catch (InvalidOperationException ex)
                {
                    this.writer.Print(ex.Message);
                }
            }
        }

        public string Status()
        {
            int reports = Controller.GetReportsCount();
            double airConditioners = Controller.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;
            return string.Format(Validation.Status, percent);
        }

        public void ValidateParametersCount(Command command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException(Validation.InvalidCommand);
            }
        }
    }
}
