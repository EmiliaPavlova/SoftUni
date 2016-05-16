using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShop
{
    public class Battery
    {
        private string model;
        private double batteryLife;

        public Battery()
        {
        }

        public Battery(string model)
        {
            this.Model = model;
        }

        public Battery(double batteryLife)
        {
            this.BatteryLife = batteryLife;
        }

        public Battery(string model, double batteryLife)
        {
            this.Model = model;
            this.BatteryLife = batteryLife;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The battery model cannot be empty!");
                }
                this.model = value;
            }
        }

        public double BatteryLife
        {
            get
            {
                return this.batteryLife;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The battery life cannot be < 0!");
                }
                this.batteryLife = value;
            }
        }
    }
}
