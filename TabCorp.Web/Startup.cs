using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TabCorp.Web.Startup))]
namespace TabCorp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
