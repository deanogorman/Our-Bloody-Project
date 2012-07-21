using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MupadoodleAPI.App_Start;
using MupadoodleAPI.DataAccess;
using System.Web.Http.Tracing;
using MupadoodleAPI.Models;

namespace MupadoodleAPI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           System.Data.Entity.Database.SetInitializer(new DBInitialiser());

           GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());

           // ApiConfig.ConfigureApi(GlobalConfiguration.Configuration);
        }
    }
}