using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartSSO.Client.B.Startup))]
namespace SmartSSO.Client.B
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
