namespace _5.EFCodeFirst_Movies
{
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new MovieContext();
            var movieCount = context.Movies.Count();
        }
    }
}
