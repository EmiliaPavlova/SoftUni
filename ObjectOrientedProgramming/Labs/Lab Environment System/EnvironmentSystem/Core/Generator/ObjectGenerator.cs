namespace EnvironmentSystem.Core.Generator
{
    using System;
    using System.Collections.Generic;

    using EnvironmentSystem.Models;
    using EnvironmentSystem.Models.Objects;
    using EnvironmentSystem.Interfaces;

    public class ObjectGenerator : IObjectGenerator<EnvironmentObject>
    {
        private const int ObjectsCount = 10;
        private const int StaticStarCount = 20;

        private readonly int worldWidth;
        private readonly int worldHeight;
        private readonly Random randomGenerator;

        public ObjectGenerator(int worldWidth, int worldHeight)
        {
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
            this.randomGenerator = new Random();
        }

        /// <summary>
        /// Adds objects only once to the passed collection. Should be used once.
        /// </summary>
        /// <param name="objects"></param>
        public IEnumerable<EnvironmentObject> SeedInitialObjects()
        {
            var generatedObjects = new List<EnvironmentObject>();
            for (int i = 0; i < StaticStarCount; i++)
            {
                int x = this.randomGenerator.Next(0, this.worldWidth);
                int y = this.randomGenerator.Next(0, 20);

            }

            generatedObjects.Add(new Ground(0, 25, 50, 2, '#'));

            Random rnd = new Random();
            
            for (int i = 0; i < 10; i++)
            {
                generatedObjects.Add(new Star(rnd.Next(0, this.worldWidth), rnd.Next(0, this.worldHeight - 5)));

                generatedObjects.Add(new UnstableStar(rnd.Next(0, this.worldWidth), rnd.Next(0, this.worldHeight - 15), new Point(rnd.Next(-1, 2), 1)));
            }
            return generatedObjects;
        }

        /// <summary>
        /// Adds the next portion of objects to the passed collection. Can be used many times.
        /// </summary>
        /// <param name="objects"></param>
        public IEnumerable<EnvironmentObject> GenerateNextObjects()
        {
            var generatedObjects = new List<EnvironmentObject>();
            for (int i = 0; i < ObjectsCount; i++)
            {
                int generateFlag = this.randomGenerator.Next(0, 5);

                if (generateFlag == 1)
                {
                    int x = this.randomGenerator.Next(0, this.worldWidth);
                    var envObject = new Snowflake(x, 1, 1, 1, new Point(0, 1));

                    generatedObjects.Add(envObject);
                }
            }

            Random rnd = new Random();
            generatedObjects.Add(new FallingStar(rnd.Next(0, this.worldWidth), rnd.Next(0, this.worldHeight - 10), 1, 1, new Point(rnd.Next(-1, 2), 1)));

            return generatedObjects;
        }
    }
}
