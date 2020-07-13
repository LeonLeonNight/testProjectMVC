using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testASPMVC.Startup))]
namespace testASPMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
