using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TestSolutions.Common.ApplicationSettings;
using TestSolutions.Common.DomainEvents;
using TestSolutions.Service.App_Start;

namespace TestSolutions.Service
{
    public class WebApiApplication : HttpApplication
    {
        void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
