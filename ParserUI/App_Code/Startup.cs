using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParserUI.Startup))]
namespace ParserUI
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app) {
      ConfigureAuth(app);
    }
  }
}
