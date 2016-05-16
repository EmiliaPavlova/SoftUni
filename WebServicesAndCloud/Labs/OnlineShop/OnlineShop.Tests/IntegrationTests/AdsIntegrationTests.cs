namespace OnlineShop.Tests.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Data;
    using EntityFramework.Extensions;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Owin;
    using Services;

    [TestClass]
    public class AdsIntegrationTests
    {
        private const string TestUserUsername = "testUser";
        private const string TestUserPassword = "123asd!";

        private static TestServer httpTestServer;
        private static HttpClient httpClient;
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
        public static void AssemblyInit(TestContext context)
        {
            httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                var startup = new Startup();

                startup.Configuration(appBuilder);
                appBuilder.UseWebApi(config);
            });

            httpClient = httpTestServer.HttpClient;
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            if (httpTestServer != null)
            {
                httpTestServer.Dispose();
            }
        }

        private static void SeedDatabase()
        {
            var context = new OnlineShopContext();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var user = new ApplicationUser()
            {
                UserName = TestUserUsername,
                Email = "prakash@yahoo.in"
            };

            var result = userManager.CreateAsync(user, TestUserPassword).Result;
            if (!result.Succeeded)
            {
                Assert.Fail(string.Join(Environment.NewLine, result.Errors));
            }

            SeedCategories(context);
            SeedAdTypes(context);
        }

        private static void SeedCategories(OnlineShopContext context)
        {
            var category = new Category()
            {
                Ads = new List<Ad>(),
                Name = "category 1"
            };

            context.Categories.Add(category);
            context.SaveChanges();
        }

        private static void SeedAdTypes(OnlineShopContext context)
        {
            var adType = new AdType()
            {
                Ads = new List<Ad>(),
                Index = 1,
                Name = "type 1",
                PricePerDay = 5
            };

            context.AdTypes.Add(adType);
            context.SaveChanges();
        }

        private static void CleanDatabase()
        {
            var context = new OnlineShopContext();

            context.Ads.Delete();
            context.AdTypes.Delete();
            context.Categories.Delete();
            context.Users.Delete();
        }

        // login
        private HttpResponseMessage Login()
        {
            var loginData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", TestUserUsername),
                new KeyValuePair<string, string>("password", TestUserPassword),
                new KeyValuePair<string, string>("grant_type", "password"), 
            });

            var response = httpClient.PostAsync("/Token", loginData).Result;

            return response;
        }

        // smth wrong
        [TestMethod]
        public void Login_Should_Return_200OK_And_Access_Token()
        {
            var loginResponse = this.Login();
            Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);

            var loginData = loginResponse.Content
                .ReadAsAsync<LoginDto>().Result;

            Assert.IsNotNull(loginData.Access_Token);
        }

        // Create Ad
        private HttpResponseMessage PostNewAd(FormUrlEncodedContent data)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.AccessToken);

            return httpClient.PostAsync("/api/ads", data).Result;
        }

        // Assert that the status code is 400 Bad Request
        [TestMethod]
        public void Posting_Ad_With_Invalid_AdType_Should_Return_Bad_Request()
        {
            var context = new OnlineShopContext();
            var category = context.Categories.First();

            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Opel Astra"),
                new KeyValuePair<string, string>("description", "..."),
                new KeyValuePair<string, string>("price", "2000"),
                new KeyValuePair<string, string>("typeId", "-1"),
                new KeyValuePair<string, string>("categories[0]", category.Id.ToString()),
            });

            var response = this.PostNewAd(data);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Assert.Fail(response.Content.ReadAsStringAsync().Result);
            }
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
