namespace Restaurants.Tests.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Restauranteur.Services.Controllers;
    using Restauranteur.Services.Models.BindingModels;
    using Restauranteur.Services.Models.ViewModels;

    [TestClass]
    public class RestaurantsControllerTests
    {
        private MockContainer mocks;

        [TestInitialize]
        public void InitTest()
        {
            this.mocks = new MockContainer();
            this.mocks.SetupMocks();
        }

        [TestMethod]
        public void GetRestaurants_ShouldReturnAllFromTown_WhenTownIdIsValid()
        {
            // Arrange
            var fakeData = this.mocks.MockData.Object;
            var existingTownId = this.mocks.TownsMock.Object.All()
                .First().Id;

            // Act
            var response = this.SendGetRestaurantsRequest(existingTownId, fakeData);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var restaurantCount = this.mocks.RestaurantsMock.Object
                .All()
                .Count(r => r.TownId == existingTownId);
            
            var restaurants = response.Content
                .ReadAsAsync<IEnumerable<RestaurantViewModel>>().Result;
            Assert.AreEqual(restaurantCount, restaurants.Count());

            foreach (var restaurant in restaurants)
            {
                Assert.IsNotNull(restaurant.Name);
                Assert.IsNotNull(restaurant.Town);
                Assert.AreEqual(existingTownId, restaurant.Town.Id);
            }
        }

        [TestMethod]
        public void GetRestaurants_ShouldReturnEmpty_WhenTownIdIsInvalid()
        {
            // Arrange
            var fakeData = this.mocks.MockData.Object;
            var invalidId = -1;

            // Act
            var response = this.SendGetRestaurantsRequest(invalidId, fakeData);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var restaurants = response.Content
                .ReadAsAsync<IEnumerable<RestaurantViewModel>>().Result;
            Assert.AreEqual(0, restaurants.Count());
        }

        private HttpResponseMessage SendGetRestaurantsRequest(int townId, IRestaurantsData data)
        {
            var model = new SearchRestaurantsBindingModel {TownId = townId };
            
            var controller = new RestaurantsController(data);
            this.SetupController(controller);

            var response = controller.GetRestaurants(model)
                .ExecuteAsync(CancellationToken.None).Result;
            return response;
        }

        private void SetupController(ApiController controller)
        {
            controller.Configuration = new HttpConfiguration();
            controller.Request = new HttpRequestMessage();
        }
    }
}
