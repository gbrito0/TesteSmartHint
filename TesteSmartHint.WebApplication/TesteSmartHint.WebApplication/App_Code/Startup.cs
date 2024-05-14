using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesteSmartHint.WebApplication.Startup))]
namespace TesteSmartHint.WebApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
