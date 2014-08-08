using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalWebsite.Controllers
{
    /// <summary>
    /// Main controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The index (default) page for the website.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// An action that displays the contact page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// An action that displays the changelist.
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeList()
        {
            return View();
        }
    }
}