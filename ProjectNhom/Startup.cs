using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectNhom.Startup))]
namespace ProjectNhom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
