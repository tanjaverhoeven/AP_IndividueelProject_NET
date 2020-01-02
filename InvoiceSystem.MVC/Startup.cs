using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvoiceSystem.MVC.Startup))]
namespace InvoiceSystem.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
