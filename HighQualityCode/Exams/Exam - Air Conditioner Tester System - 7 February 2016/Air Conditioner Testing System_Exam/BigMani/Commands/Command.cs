namespace AirConditionerSystem.Commands
{
    using System;
    using Files;
    using Interfaces;

    public class Command : ICommand
    {
        public Command(string line)
        {
            try
            {
                this.Name = line.Substring(0, line.IndexOf(string.Empty));

                this.Parameters = line.Substring(line.IndexOf(string.Empty))
                    .Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Validation.InvalidCommand, ex);
            }
        }

        public string Name { get; private set; }

        public string[] Parameters { get; private set; }
    }
}
