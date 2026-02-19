using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace App_WebForm
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que é executado na inicialização do aplicativo
            RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("HomeRoute", "", "~/Default.aspx");
            routes.MapPageRoute("SobreRoute", "Sobre", "~/Modulos/ItensMenu/Sobre.aspx");
            routes.MapPageRoute("MySQLRoute", "MySQL", "~/Modulos/ItensMenu/MySQL.aspx");
        }
    }
}