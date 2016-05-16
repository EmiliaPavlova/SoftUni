namespace Restaurants.Data
{
    using Models;
    using Repositories;
    using Restauranteur.Models;

    public interface IRestaurantsData
    {
        IRepository<Restaurant> Restaurants { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<Town> Towns { get; }

        IRepository<Meal> Meals { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<MealType> MealTypes { get; }

        IRepository<Order> Orders { get; }

        int SaveChanges();
    }
}
