using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bricks.Startup))]
namespace Bricks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
