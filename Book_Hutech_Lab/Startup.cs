using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Book_Hutech_Lab.Startup))]
namespace Book_Hutech_Lab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
