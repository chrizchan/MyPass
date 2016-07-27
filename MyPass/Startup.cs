using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyPass.Startup))]
namespace MyPass
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
