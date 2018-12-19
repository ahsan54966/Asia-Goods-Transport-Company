using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fyp_First_Increment.Startup))]
namespace Fyp_First_Increment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
