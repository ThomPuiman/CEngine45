using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CEngine45.Startup))]
namespace CEngine45
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
