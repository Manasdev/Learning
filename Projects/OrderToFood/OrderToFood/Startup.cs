using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrderToFood.Startup))]
namespace OrderToFood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
