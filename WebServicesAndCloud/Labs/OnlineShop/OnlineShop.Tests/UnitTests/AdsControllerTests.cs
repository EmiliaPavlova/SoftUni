namespace OnlineShop.Tests.UnitTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;
    using Services.Controllers;
    using Services.Infrastructure;
    using Services.Models;

    [TestClass]
    public class AdsControllerTests
    {
        private MockContainer mocks;

        [TestInitialize]
        public void InitTest()
        {
            this.mocks = new MockContainer();
            this.mocks.PrepareMocks();
        }

        [TestMethod]
        public void GetAllAds_Should_Return_Total_Ads_Sorted_By_TypeIndex()
        {
            var fakeAds = this.mocks.AdRepositoryMock.Object.All();

            var mockContext = new Mock<IOnlineShopData>();
            mockContext.Setup(c => c.Ads).Returns(this.mocks.AdRepositoryMock.Object);

            var adsController = new AdsController(mockContext.Object, null);
            adsController.Request = new HttpRequestMessage();
            adsController.Configuration = new HttpConfiguration();

            var response = adsController.OpenAds()
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var adsResponse = response.Content
                .ReadAsAsync<IEnumerable<AdViewModel>>()
                .Result
                .Select(a => a.Id)
                .ToList();

            var orderedfakeAds = fakeAds
                .OrderBy(a => a.Type.Index)
                .ThenBy(a => a.PostedOn)
                .Select(a => a.Id)
                .ToList();

            CollectionAssert.AreEqual(orderedfakeAds, adsResponse);
        }

        [TestMethod]
        public void CreateAd_Should_Successfully_Add_To_Repository()
        {
            var ads = new List<Ad>();

            var fakeUser = this.mocks.UserRepositoryMock.Object.All()
                .FirstOrDefault();
            if (fakeUser == null)
            {
                Assert.Fail("Cannot perform test - no users available.");
            }

            this.mocks.AdRepositoryMock
                .Setup(r => r.Add(It.IsAny<Ad>()))
                .Callback((Ad ad) =>
                {
                    ad.Owner = fakeUser;
                    ads.Add(ad);
                });

            var mockContext = new Mock<IOnlineShopData>();
            mockContext.Setup(c => c.Ads)
                .Returns(this.mocks.AdRepositoryMock.Object);
            mockContext.Setup(c => c.Categories)
                .Returns(this.mocks.CategoryRepositoryMock.Object);
            mockContext.Setup(c => c.Users)
                .Returns(this.mocks.UserRepositoryMock.Object);
            mockContext.Setup(c => c.AdTypes)
                .Returns(this.mocks.AdTypeRepositoryMock.Object);

            var mockIdProvider = new Mock<IUserIdProvider>();
            mockIdProvider.Setup(ip => ip.GetUserId())
                .Returns(fakeUser.Id);

            var adsController = new AdsController(mockContext.Object, mockIdProvider.Object);
            this.SetupController(adsController);

            var randomName = Guid.NewGuid().ToString();
            var newAd = new CreateAdBindingModel()
            {
                Name = randomName,
                Price = 555,
                TypeId = 1,
                Description = "Nothing to say",
                Categories = new[] {1, 2, 3}
            };

            var response = adsController.CreateAd(newAd)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            mockContext.Verify(c => c.SaveChanges(), Times.Once);

            Assert.AreEqual(ads.Count, 1);
            Assert.AreEqual(ads[0].Name, newAd.Name);
        }
        private void SetupController(AdsController adsController)
        {
            adsController.Request = new HttpRequestMessage();
            adsController.Configuration = new HttpConfiguration();
        }
    }
}
