using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_App_Entity_Framework_DB_First_Approach.Models;

namespace Udemy_App_Entity_Framework_DB_First_Approach.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
            List <Category> categories = db.Categories.ToList(); ;
            return View(categories);
        }
    }
}