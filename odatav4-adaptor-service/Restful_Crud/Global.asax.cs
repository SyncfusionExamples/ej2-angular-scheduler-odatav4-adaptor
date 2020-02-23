using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Restful_Crud
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(config =>
            {
                ODataConfig.Register(config);
            });
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Prefer, Authorization");
                HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, PUT, POST, DELETE, HEAD, PATCH, OPTIONS");
                HttpContext.Current.Response.End();
            }
        }
    }
}
