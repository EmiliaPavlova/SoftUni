namespace Restaurants.Tests.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Data;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Owin;
    using Services;
    using Services.Models.ViewModels;

    [TestClass]
    public class MealsIntegrationTests
    {
        private const string TestUserUsername = "motikarq";
        private const string TestUserPassword = "motikarq";

        private static TestServer server;
        private static HttpClient client;

        private string accessToken;

        private string AccessToken
        {
            get
            {
                if (this.accessToken == null)
                {
                    var loginResponse = this.Login();
                    if (!loginResponse.IsSuccessStatusCode)
                    {
                        Assert.Fail("Unable to login: " + loginResponse.ReasonPhrase);
                    }

                    var loginData = loginResponse.Content
                        .ReadAsAsync<LoginDto>().Result;

                    this.accessToken = loginData.Access_Token;
                }

                return this.accessToken;
            }
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            // Create in-memory test server
            server = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);

                var startup = new Startup();
                startup.Configuration(appBuilder);

                appBuilder.UseWebApi(config);
            });

            client = server.HttpClient;

            // Use custom seed class
            var seedConfig = new SeedConfiguration(TestUserUsername, TestUserPassword);
            seedConfig.Seed();
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            if (server != null)
            {
                server.Dispose();
            }
        }

        [TestMethod]
        public void EditOwnRestaurantMeal_WithNewCorrectData_ShouldChangeMeal_And_Return200OK()
        {
            // Arrange
            var context = new RestaurantsContext();
            var ownMeal = context.Meals
                .First(m => m.Restaurant.Owner.UserName == TestUserUsername);
            var type = context.MealTypes.First(t => t.Id != ownMeal.TypeId);

            var newName = DateTime.Now.Ticks.ToString();
            var newPrice = decimal.Parse(string.Format("{0}.{1}",
                DateTime.Now.Ticks % 10, DateTime.Now.Ticks % 100));
            var newType = type.Name;

            // Act
            this.SetAuthorizationHeaders(true);

            var response = this.SendEditMealRequest(ownMeal.Id, newName, newPrice, type.Id);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var meal = response.Content.ReadAsAsync<MealViewModel>().Result;
            Assert.AreEqual(newName, meal.Name);
            Assert.AreEqual(newPrice, meal.Price);
            Assert.AreEqual(newType, meal.Type);
        }

        [TestMethod]
        public void EditOwnRestaurantMeal_WithInvalidMealId_ShouldReturn400BadRequest()
        {
            // Arrange
            var context = new RestaurantsContext();
            var ownMeal = context.Meals
                .First(m => m.Restaurant.Owner.UserName == TestUserUsername);

            var newName = DateTime.Now.Ticks.ToString();
            var newPrice = decimal.Parse(string.Format("{0}.{1}",
                DateTime.Now.Ticks % 10, DateTime.Now.Ticks % 100));
            var invalidMealType = -1;

            // Act
            this.SetAuthorizationHeaders(true);

            var response = this.SendEditMealRequest(ownMeal.Id, newName, newPrice, invalidMealType);

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void EditRestaurantMeal_WithoutAccessToken_ShouldReturn401Unauthorized()
        {
            // Arrange
            var context = new RestaurantsContext();
            var ownMeal = context.Meals
                .First(m => m.Restaurant.Owner.UserName == TestUserUsername);
            var type = context.MealTypes.First(t => t.Id != ownMeal.TypeId);

            var newName = DateTime.Now.Ticks.ToString();
            var newPrice = decimal.Parse(string.Format("{0}.{1}",
                DateTime.Now.Ticks % 10, DateTime.Now.Ticks % 100));

            // Act
            this.SetAuthorizationHeaders(false);

            var response = this.SendEditMealRequest(ownMeal.Id, newName, newPrice, type.Id);

            // Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        private HttpResponseMessage SendEditMealRequest(int mealId, string name, decimal price, int typeId)
        {
            var model = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", name),
                new KeyValuePair<string, string>("price", price.ToString()),
                new KeyValuePair<string, string>("typeId", typeId.ToString())
            });

            return client.PutAsync("api/meals/" + mealId, model).Result;
        }

        private HttpResponseMessage Login()
        {
            var loginData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", TestUserUsername),
                new KeyValuePair<string, string>("password", TestUserPassword),
                new KeyValuePair<string, string>("grant_type", "password")
            });

            var response = client.PostAsync("api/account/login", loginData).Result;

            return response;
        }

        private void SetAuthorizationHeaders(bool isLogged)
        {
            client.DefaultRequestHeaders.Remove("Authorization");
            if (isLogged)
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.AccessToken);
            }
        }
    }
}
