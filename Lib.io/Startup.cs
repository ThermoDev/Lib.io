using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lib.io.Startup))]
namespace Lib.io
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
