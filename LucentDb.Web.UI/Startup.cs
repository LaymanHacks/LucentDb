using LucentDb.Web.UI;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace LucentDb.Web.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}