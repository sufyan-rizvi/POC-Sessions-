using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POC_Sessions_and_Session_Timeout.Controllers
{
    public class ComplexController : Controller
    {
        
        public ActionResult Entry()
        {
            // Set user session on login
            Session["UserName"] = "John Doe";//Keeps data till the session is over and can be used again and again
            Session["LoginTime"] = DateTime.Now; 
            return View();
        }

       
        public ActionResult Dashboard()
        {
            if (Session["UserName"] == null)
            {
                
                return RedirectToAction("SessionExpiry");
            }

          
            ViewBag.UserName = Session["UserName"].ToString();
            ViewBag.TimeLeft = 20 - (DateTime.Now - (DateTime)Session["LoginTime"]).TotalMinutes; 
            return View();
        }

       
        public ActionResult SessionExpiry()
        {
            ViewBag.Message = "Your session has expired. Please log in again.";
            return View();
        }
    }
}
