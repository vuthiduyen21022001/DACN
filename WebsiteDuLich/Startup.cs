using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteDuLich.Startup))]
namespace WebsiteDuLich
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
         
        }
    }
}
