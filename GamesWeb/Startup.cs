using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamesWeb.Startup))]
namespace GamesWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
