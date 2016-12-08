using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tienda_compu.Startup))]
namespace Tienda_compu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
