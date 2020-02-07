using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagementStudent.Startup))]
namespace ManagementStudent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
