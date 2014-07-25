using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PersonalWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // dynamically add redirection links based on the keys in the webconfig.
            var links = ConfigurationManager.AppSettings.AllKeys;
            foreach (var link in links)
            {
                if (link.StartsWith(Constants.LinkHeader))
                {
                    var linkName = link.Substring(Constants.LinkHeader.Length);
                    routes.MapRoute(
                        name: linkName,
                        url: linkName.ToLower(),
                        defaults: new { controller = "Redirect", action = linkName }
                    );
                }
            }

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
