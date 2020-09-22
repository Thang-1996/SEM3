using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPLesson1.Startup))]
namespace ASPLesson1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
