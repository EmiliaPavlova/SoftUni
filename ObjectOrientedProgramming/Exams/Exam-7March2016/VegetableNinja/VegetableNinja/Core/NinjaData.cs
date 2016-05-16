namespace VegetableNinja.Core
{
    using System.Collections.Generic;
    using Interfaces;

    public class NinjaData : INinjaData
    {
        private readonly ICollection<INinja> ninjas;

        public NinjaData(ICollection<INinja> ninjas)
        {
            this.ninjas = ninjas;
        }

        public IEnumerable<INinja> Ninjas => this.ninjas;

        public void SetNinja(INinja ninja)
        {
            this.ninjas.Add(ninja);
        }

        public IDictionary<char, int> Vegetables { get; set; }
    }
}