using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ALProject.Startup))]
namespace ALProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
