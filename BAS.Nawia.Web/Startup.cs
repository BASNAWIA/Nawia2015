using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BAS.Nawia.Web.Startup))]
namespace BAS.Nawia.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
