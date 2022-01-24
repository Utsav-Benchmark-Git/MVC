using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_App_Model_Example.Models;

namespace Udemy_App_Model_Example.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new Product(){ ProductId = 101, ProductName = "AC", Rate = 30000},
                new Product(){ ProductId = 102, ProductName = "Refrigerator", Rate = 40000},
                new Product(){ ProductId = 103, ProductName = "Car", Rate = 50000},
            };
            return View(products);
        }

        public ActionResult Details(int id)
        {
            List<Product> products = new List<Product>()
            {
                new Product(){ ProductId = 101, ProductName = "AC", Rate = 30000},
                new Product(){ ProductId = 102, ProductName = "Refrigerator", Rate = 40000},
                new Product(){ ProductId = 103, ProductName = "Car", Rate = 50000},
            };
            Product matchedProduct = null;
            foreach (var p in products)
            {
                if (p.ProductId == id)
                {
                    matchedProduct = p;
                }
            }
            return View("Details", matchedProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            return View();
        }
    }
}