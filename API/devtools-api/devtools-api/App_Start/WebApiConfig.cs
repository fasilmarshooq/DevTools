using devtools_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace devtools_api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            QueryHelperService queryHelper = new QueryHelperService();
            config.EnableCors();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
      
    }
}
