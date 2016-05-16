using Microsoft.Owin;
using Restaurants.Services;

[assembly: OwinStartup(typeof(Startup))]

namespace Restaurants.Services
{
    using System.Data.Entity;
    using System.Web.Http;
    using Data;
    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var kernel = new StandardKernel();
            kernel.Bind<IRestaurantsData>().To<RestaurantsData>();
            kernel.Bind<DbContext>().To<RestaurantsContext>();

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseNinjectMiddleware(() => kernel)
               .UseNinjectWebApi(config);
        }
    }
}
