using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VolumeCalculatorWebApp.Startup))]
namespace VolumeCalculatorWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
