namespace _5.EFCodeFirst_Movies.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<_5.EFCodeFirst_Movies.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "_5.EFCodeFirst_Movies.MovieContext";
        }

        protected override void Seed(_5.EFCodeFirst_Movies.MovieContext context)
        {
            AddCountries(context);
            AddUsers(context);
        }

        private static void AddCountries(MovieContext context)
        {
            var json = File.ReadAllText("../../countries.json");
            List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(json);
            foreach (var country in countries)
            {
                context.Countries.Add(country);
            }
            context.SaveChanges();
        }

        private static void AddUsers(UserDTO userDto)
        {
            var json = File.ReadAllText("../../users.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            foreach (var user in users)
            {
                try
                {
                    ImportContactToDatabase(users);
                    //Console.WriteLine("Contact {0} imported", parsedContact.Name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }

        private static void ImportContactToDatabase(UserDTO userDto)
        {
            var context = new MovieContext();
            var newUser = new User()
            {
                Username = userDto.Username,
                Age = userDto.Age,
                Email = userDto.Email,
                CountryId = context.Users.FirstOrDefault(u => u.CountryId == countryId)
            };
            context.Users.Add(newUser);
            context.SaveChanges();
        }
    }
}
