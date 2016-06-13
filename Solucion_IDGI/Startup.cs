using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Solucion_IDGI.Startup))]
namespace Solucion_IDGI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
