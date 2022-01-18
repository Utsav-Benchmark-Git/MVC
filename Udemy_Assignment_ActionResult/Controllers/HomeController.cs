using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Udemy_Assignment_ActionResult.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string arg)
        {
            if(arg == "sample")
            {
                return File("~/sample.pdf", "application/pdf");
            }
            else if(arg == "about")
            {
                return RedirectToAction("About");
            }
            else if (arg == "login")
            {
                return View("Login");
            }
            else
            {
                return Content("You entered : "+arg);
            }
        }
        public ActionResult About()
        {
            return Content("ABout Page");
        }
    }
}