using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Webbandohh.Startup))]
namespace Webbandohh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
