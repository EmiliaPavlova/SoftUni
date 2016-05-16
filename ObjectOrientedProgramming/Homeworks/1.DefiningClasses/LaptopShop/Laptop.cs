using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShop
{
    public class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private int ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private decimal price;

        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop(string model, decimal price, Battery battery) : this(model, price)
        {
            this.Model = model;
            this.Price = price;
            this.Batt = battery;
        }

        public Laptop(string model, decimal price, string manufacturer, string processor, int ram, string graphicsCard, string hdd, string screen, Battery battery)
            : this(model, price)
        {
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.Screen = screen;
        }

        public string Model
        {
            get
            {
                return this.model;

            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The model cannot be empty!");
                }
                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price cannot be negative number!");
                }
                this.price = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The manufactuer cannot be empty!");
                }
                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get
            {
                return this.processor;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The processor cannot be empty!");
                }
                this.processor = value;
            }
        }

        public int Ram
        {
            get
            {
                return this.ram;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The RAM cannot be negative number!");
                }
                this.ram = value;
            }
        }

        public string GraphicsCard
        {
            get
            {
                return this.graphicsCard;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The Graphics Card cannot be empty!");
                }
                this.graphicsCard = value;
            }
        }

        public string Hdd
        {
            get
            {
                return this.hdd;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The HDD cannot be empty!");
                }
                this.hdd = value;
            }
        }

        public string Screen
        {
            get
            {
                return this.screen;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The Screen cannot be empty!");
                }
                this.screen = value;
            }
        }

        public Battery Batt { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Laptop description:");
            result.AppendLine("Model: " + this.Model);
            if (manufacturer != null)
            {
                result.AppendLine("Manufacturer: " + this.Manufacturer);
            }
            if (processor != null)
            {
                result.AppendLine("Processor: " + this.Processor);
            }
            if (ram > 0)
            {
                result.AppendLine("RAM: " + this.Ram + " GB");
            }
            if (graphicsCard != null)
            {
                result.AppendLine("Graphics card: " + this.GraphicsCard);
            }
            if (hdd != null)
            {
                result.AppendLine("HDD: " + this.Hdd);
            }
            if (screen != null)
            {
                result.AppendLine("Screen: " + this.Screen);
            }
            if (Batt.BatteryLife > 0)
            {
                result.AppendLine("Battery: " + this.Batt.Model);
            }
            if (Batt.Model != null)
            {
                result.AppendLine("Battery life: " + this.Batt.BatteryLife + " hours");
            }
            result.AppendLine("Price: " + this.Price + " lv.");
            return result.ToString();
        }
    }
}
