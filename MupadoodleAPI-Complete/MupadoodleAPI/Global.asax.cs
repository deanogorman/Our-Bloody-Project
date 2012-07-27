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
using System.Web.Security;
using MupadoodleAPI.Models;

using System.Web.SessionState;
using System.ServiceModel.Activation;
using MupadoodleAPI.Logic;


namespace MupadoodleAPI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        static void Configure(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new ApiKeyHandler("1234-abcd"));
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           System.Data.Entity.Database.SetInitializer(new DBInitialiser());

           GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());

           Configure(GlobalConfiguration.Configuration);

           ApiConfig.ConfigureApi(GlobalConfiguration.Configuration);
        }
    }

}