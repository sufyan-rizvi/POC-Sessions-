using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POC_Sessions_and_Session_Timeout.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["user"] = "Sufyan";
            return RedirectToAction("page2");
            
        }

        public ActionResult Page2()
        {
            if(Session["user"] != null)
                return View();
            return RedirectToAction("SessionExpired");
        }
        public ActionResult SessionExpired()
        {
            return View();
        } 
    }
}