using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCatalog
{
    public class Component
    {
        private string componentName;
        private decimal price;

        public Component(string componentName, decimal price)
        {
            this.ComponentName = componentName;
            this.Price = price;
        }

        public Component(string componentName, decimal price, string details) : this(componentName, price)
        {
            this.Details = details;
        }

        public string ComponentName
        {
            get
            {
                return this.componentName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The component cannot be left blank!");
                }
                this.componentName = value;
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
                    throw new ArgumentOutOfRangeException("value", "The price cannot be negative.");
                }
                this.price = value;
            }
        }

        public string Details { get; set; }
    }
}