namespace VegetableNinja.Core
{
    using System;
    using Interfaces;
    using Models;

    public class Engine : IRunnable
    {
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;
        private readonly INinjaData data;

        public Engine(IInputReader reader, IOutputWriter writer, INinjaData data)
        {
            this.reader = reader;
            this.writer = writer;
            this.data = data;
        }

        public void Run()
        {
            while (true)
            {
                var ninjaName1 = this.reader.Read();
                var ninjaName2 = this.reader.Read();
                var dimensions = this.reader.Read().Split();
                var fieldWidth = int.Parse(dimensions[0]);
                var fielsHeight = int.Parse(dimensions[1]);
                var input = this.reader.Read();
                this.Move(input, ninjaName1, ninjaName2, fieldWidth, fielsHeight);
                //this.CheckNinjaTurn(ninjaName1, ninjaName2);
                this.UpdateGame();
            }
        }

        private void Move(string input, string ninja1, string ninja2, int fieldWidth, int fielsHeight)
        {
            var row = 0;
            var col = 0;

            foreach (char c in input)
            {
                switch (c)
                {
                    case 'U':
                        break;
                    case 'R':
                        break;
                    case 'D':
                        break;
                    case 'L':
                        break;
                    default:
                        if (c == ninja1[0])
                        {
                            
                        }
                        if (c == ninja2[0])
                        {

                        }
                        break;
                }
            }
        }

        private INinja CheckNinjaTurn(INinja ninja1, INinja ninja2)
        {
            if (ninja1.Stamina > 0)
            {
                return ninja1;
            }
            else
            {
                return ninja2;
            }
        }

        private void UpdateGame()
        {
            throw new System.NotImplementedException();
        }


    }
}