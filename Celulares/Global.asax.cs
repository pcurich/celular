using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Celulares
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        static bool IsLocalDb = System.Configuration.ConfigurationManager.AppSettings["IsLocalDb"].ToString().Equals("true");

        static bool StartUpDrop = System.Configuration.ConfigurationManager.AppSettings["DbStage"].ToString().Equals("Drop");
        static bool StartUpNormal = System.Configuration.ConfigurationManager.AppSettings["DbStage"].ToString().Equals("Normal");

        public static string ConnectionString = IsLocalDb ? "Local" : "AppHb";

        protected void Application_Start()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");

            
            AreaRegistration.RegisterAllAreas();
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            Database.SetInitializer<DBContext>(new Celulares.DBContext.InitializerDropAlways());
        }
    }
}