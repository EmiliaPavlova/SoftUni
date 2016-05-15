using System;
using System.Collections.Generic;
using System.Linq;

namespace BoatRacingSimulator
{
    using BoatRacingSimulator.Core;

    public class BoatRacingSimulatorApplication
    {
        public static void Main()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
