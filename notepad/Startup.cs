using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(notepad.Startup))]
namespace notepad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
