using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartSSO.Client.Startup))]
namespace SmartSSO.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
