using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MLandfill.Startup))]
namespace MLandfill
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
