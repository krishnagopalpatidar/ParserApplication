<%@ Application Language="C#" %>
<%@ Import Namespace="ParserUI" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

  void Application_Start(object sender, EventArgs e)
  {
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
  }

  void Application_Error(object sender, EventArgs e) {
      Exception ex = Server.GetLastError();
      //Here we can write our custom logic to show specific error messages in desired format and page etc.
      //The exception type which are not handled here, will be forwarded to default redirect error page as per config. 
  }


</script>
