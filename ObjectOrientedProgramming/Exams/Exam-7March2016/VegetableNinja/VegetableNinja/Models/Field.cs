namespace VegetableNinja.Models
{
    using Interfaces;

    public class Field : IField
    {
        private int width;
        private int height;

        public Field(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; protected set; }

        public int Height { get; protected set; }
    }
}