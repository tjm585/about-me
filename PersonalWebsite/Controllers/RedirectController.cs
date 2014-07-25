using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalWebsite.Controllers
{
    /// <summary>
    /// A controller solely for redirecting to external sites.
    /// </summary>
    public class RedirectController : Controller
    {
        /// <summary>
        /// Action that redirects to LinkedIn.
        /// </summary>
        /// <returns></returns>
        public ActionResult LinkedIn()
        {
            return RedirectFromConfiguration("LinkedIn");
        }

        /// <summary>
        /// Action that redirects to GitHub.
        /// </summary>
        /// <returns></returns>
        public ActionResult GitHub()
        {
            return RedirectFromConfiguration("GitHub");
        }

        /// <summary>
        /// Action that redirects to Facebook.
        /// </summary>
        /// <returns></returns>
        public ActionResult Facebook()
        {
            return RedirectFromConfiguration("Facebook");
        }

        /// <summary>
        /// Action that redirects to Twitter.
        /// </summary>
        /// <returns></returns>
        public ActionResult Twitter()
        {
            return RedirectFromConfiguration("Twitter");
        }

        /// <summary>
        /// Action that redirects to GooglePlus.
        /// </summary>
        /// <returns></returns>
        public ActionResult GooglePlus()
        {
            return RedirectFromConfiguration("GooglePlus");
        }

        /// <summary>
        /// Returns a <see cref="RedirectResult"/> that redirects to the url
        /// specified in the configuration file.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private RedirectResult RedirectFromConfiguration(string key)
        {
            string link = GetUrlFromConfiguration(key);
            return Redirect(link);
        }

        /// <summary>
        /// Helper method to get the link url from the config file.
        /// </summary>
        /// <param name="urlName"></param>
        /// <returns></returns>
        private string GetUrlFromConfiguration(string urlName)
        {
            string key = string.Format("{0}{1}", Constants.LinkHeader, urlName);
            string link = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(link))
            {
                string userName = ConfigurationManager.AppSettings[Constants.PersonalInfoName] ?? "The user";
                string errorMessage = string.Format("{0} does not have a {1} account.", userName, urlName);
                throw new HttpException(404, errorMessage);
            }

            return link;
        }
    }
}