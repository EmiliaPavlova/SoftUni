namespace OnlineShop.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using Data;
    using Models;
    using Moq;

    public class MockContainer
    {
        public Mock<IRepository<Ad>> AdRepositoryMock { get; set; }

        public Mock<IRepository<Category>> CategoryRepositoryMock { get; set; }

        public Mock<IRepository<AdType>> AdTypeRepositoryMock { get; set; }

        public Mock<IRepository<ApplicationUser>> UserRepositoryMock { get; set; }

        public void PrepareMocks()
        {
            this.SetupFakeAds();
            this.SetupFakeCategories();
            this.SetupFakeAdTypes();
            this.SetupFakeUsers();
        }

        private void SetupFakeAds()
        {
            var fakeAds = new List<Ad>()
            {
                new Ad()
                {
                    Id = 5,
                    Name = "Audi A6",
                    Type = new AdType()
                    {
                        Name = "Normal",
                        Index = 101
                    },
                    PostedOn = DateTime.Now.AddDays(-6),
                    Owner = new ApplicationUser()
                    {
                        UserName = "gosho",
                        Id = "123"
                    },
                    Price = 400
                },
                new Ad()
                {
                    Id = 2,
                    Name = "BMW X5",
                    Type = new AdType()
                    {
                        Name = "Premium",
                        Index = 200
                    },
                    PostedOn = DateTime.Now,
                    Owner = new ApplicationUser()
                    {
                        UserName = "theCool",
                        Id = "555"
                    },
                    Price = 1400
                }
            };

            this.AdRepositoryMock = new Mock<IRepository<Ad>>();
            this.AdRepositoryMock.Setup(r => r.All()).Returns(fakeAds.AsQueryable());

            this.AdRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    // todo: return ad from fake ads with the corresponding id
                    return null;
                });
        }

        private void SetupFakeCategories()
        {
            var fakeCategories = new List<Category>()
            {
                new Category(){Id = 1, Name = "Cat1"},
                new Category(){Id = 2, Name = "Cat2"},
                new Category(){Id = 3, Name = "Cat3"},
            };
            this.CategoryRepositoryMock = new Mock<IRepository<Category>>();
            this.CategoryRepositoryMock.Setup(r => r.All()).Returns(fakeCategories.AsQueryable());
        }

        private void SetupFakeAdTypes()
        {
            var fakeAdTypes = new List<AdType>()
            {
                new AdType(){Id = 1, Name = "100"},
                new AdType(){Id = 2, Name = "200"},
                new AdType(){Id = 3, Name = "400"},
            };

            this.AdTypeRepositoryMock = new Mock<IRepository<AdType>>();
            this.AdTypeRepositoryMock.Setup(r => r.All()).Returns(fakeAdTypes.AsQueryable());
        }

        private void SetupFakeUsers()
        {
            var fakeUsers = new List<ApplicationUser>()
            {
                new ApplicationUser(){UserName = "Some1", Id = "1"},
                new ApplicationUser(){UserName = "Some2", Id = "2"},
                new ApplicationUser(){UserName = "Some3", Id = "3"},
            };
            this.UserRepositoryMock = new Mock<IRepository<ApplicationUser>>();
            this.UserRepositoryMock.Setup(r => r.All()).Returns(fakeUsers.AsQueryable());
        }
    }
}
