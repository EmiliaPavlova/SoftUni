using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCatalog
{
    public class Computer
    {
        private string name;
        private List<Component> components;
        private decimal price;

        public Computer(string name, List<Component> components)
        {
            this.Name = name;
            this.Components = components;
            this.Price = components.Sum(component => component.Price);
        }

        public Computer(string name) : this(name, new List<Component>())
        {
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name cannot be left blank.");
                }
                this.name = value;
            }
        }

        public List<Component> Components
        {
            get
            {
                return this.components;
            }
            set
            {
                this.components = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                decimal totalPrice = this.Components.Sum(component => component.Price);
                this.price = totalPrice;
            }
        }

        public void GetComponents()
        {
            if (components.Count != 0)
            {
                foreach (var component in this.Components)
                {
                    Console.WriteLine("{0}, price: {1:f} BGN", component.ComponentName, component.Price);
                }
            }
        }

        public void GetPrice()
        {
            Console.WriteLine("Total price: {0:f} BGN", this.price);
        }

        public void GetName()
        {
            Console.WriteLine("Computer name: {0}", this.name);
        }

        public override string ToString()
        {
            return string.Format("Computer name: {0}, price: {1:f} BGN", this.name, this.price);
        }
    }
}
