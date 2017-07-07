using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartSSO.Passport.Startup))]
namespace SmartSSO.Passport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
