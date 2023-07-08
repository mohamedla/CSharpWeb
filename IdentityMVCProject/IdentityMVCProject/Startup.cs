using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityMVCProject.Startup))]
namespace IdentityMVCProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
