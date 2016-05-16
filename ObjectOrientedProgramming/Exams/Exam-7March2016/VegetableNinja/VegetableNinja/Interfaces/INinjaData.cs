namespace VegetableNinja.Interfaces
{
    using System.Collections.Generic;

    public interface INinjaData
    {
        IEnumerable<INinja> Ninjas { get; }

        void SetNinja(INinja ninja);

        IDictionary<char, int> Vegetables { get; set; }
    }
}