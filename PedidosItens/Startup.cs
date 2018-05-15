using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PedidosItens.Startup))]
namespace PedidosItens
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
