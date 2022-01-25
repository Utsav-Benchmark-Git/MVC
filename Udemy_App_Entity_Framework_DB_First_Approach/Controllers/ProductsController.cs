using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_App_Entity_Framework_DB_First_Approach.Models;

namespace Udemy_App_Entity_Framework_DB_First_Approach.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products/Index
        public ActionResult Index(string search = "")
        {
            EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
            ViewBag.search = search;
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();
            return View(products);
        }

        //GET : Products/Details
        public ActionResult Details(long id)
        {
            EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(long ?id)
        {
            EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(existingProduct);
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
            Product existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.DateOfPurchase = p.DateOfPurchase;
            existingProduct.BrandID = p.BrandID;
            existingProduct.CategoryID = p.CategoryID;
            existingProduct.AvailabilityStatus = p.AvailabilityStatus;
            existingProduct.Active = p.Active;

            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }


        [HttpGet]
        public ActionResult Delete(long id)
        {
            EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Delete(long id, Product p)
        {
            EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            db.Products.Remove(existingProduct);
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}