using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantsRecomendation.Startup))]
namespace RestaurantsRecomendation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
