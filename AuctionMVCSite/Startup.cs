using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuctionMVCSite.Startup))]
namespace AuctionMVCSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
