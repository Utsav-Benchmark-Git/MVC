using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Udemy_App_Url_Routing.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [Route("")]
        [Route("Product/")]
        [Route("Product/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Product/GetProductName/{id:int?}")]
        public ActionResult GetProductName(int? id)
        {
            var products = new[] {
                new { ProductId = 1, ProductName = "Phone", Cost = 11111},
                new { ProductId = 2, ProductName = "Laptop", Cost = 222222},
                new { ProductId = 3, ProductName = "TV", Cost = 33333},
            };
            if (id == null)
            {
                return Content("Please enter valid Product Id");
            }
            else
            {
                string prodName = "";
                foreach(var p in products)
                {
                    if(p.ProductId == id)
                    {
                        prodName = p.ProductName;
                    }
                }
                return Content(prodName);
            }

        }
        [Route("Product/GetProductId/{productName}")]
        public ActionResult GetProductId(string productName)
        {
            var products = new[] {
                new { ProductId = 1, ProductName = "Phone", Cost = 11111},
                new { ProductId = 2, ProductName = "Laptop", Cost = 222222},
                new { ProductId = 3, ProductName = "TV", Cost = 33333},
            };
            if (productName == null)
            {
                return Content("Please enter valid Product Id");
            }
            else
            {
               int prodId = 0;
                foreach (var p in products)
                {
                    if (p.ProductName == productName)
                    {
                        prodId = p.ProductId;
                    }
                }
                return Content(prodId.ToString());
            }

        }
    }
}