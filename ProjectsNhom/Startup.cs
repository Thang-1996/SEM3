using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectsNhom.Startup))]
namespace ProjectsNhom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
