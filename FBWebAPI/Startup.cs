using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FBWA.Startup))]

namespace FBWA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
