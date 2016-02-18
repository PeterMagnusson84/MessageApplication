using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ViewMessagesApplication.Startup))]
namespace ViewMessagesApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
