
using BigMani.GoodStuff;
using BigMani.Work;

namespace BigMani.Wokr
{
    using System;
    using BigMani.Interfaces;

    public class Engine
    {
        public Baito ac;

        public IUserInterface ui;

        public Command magic;

        public Engine(IUserInterface userInterface)
        {
            this.ac = new Baito(this);
            this.ui = userInterface;
        }


        public void Run()
        {
            while (true)
            {
                string line = this.ui.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    magic = new Command(line);
                    this.ac.DoMagic();
                }
                catch (InvalidOperationException ex)
                {
                    this.ui.WriteLine(ex.Message);
                }
            }
        }

        public string Status()
        {
            int reports = MyStuff.GetReportsCount();
            double airConditioners = MyStuff.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;
            return string.Format(GoodStuff.GoodStuff.STATUS, percent);
        }

        public void ValidateParametersCount(Command command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException(GoodStuff.GoodStuff.INVALIDCOMMAND);
            }
        }
    }
}
