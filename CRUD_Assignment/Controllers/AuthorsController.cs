using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Assignment.Models;

namespace CRUD_Assignment.Controllers
{
    public class AuthorsController : Controller
    {
        CRUD_AssignmentEntities db = new CRUD_AssignmentEntities();

        // GET: Authors
        public ActionResult Index(string search="", string SortColumn = "AuthorID", string IconClass = "fa-sort-asc")
        {
            //Searching
            ViewBag.search = search;
            List<Author> authors= db.Authors.Where(temp => temp.AuthorName.Contains(search)).ToList();
            ViewBag.Message = "Authors Table";


            //Sorting
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            //Sorting by Author ID
            if (ViewBag.SortColumn == "AuthorID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    authors = authors.OrderBy(temp => temp.AuthorID).ToList();
                }
                else
                {
                    authors = authors.OrderByDescending(temp => temp.AuthorID).ToList();
                }
            }


            //Sorting by Author Name
            if (ViewBag.SortColumn == "AuthorName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    authors = authors.OrderBy(temp => temp.AuthorName).ToList();
                }
                else
                {
                   authors = authors.OrderByDescending(temp => temp.AuthorName).ToList();
                }
            }


            return View(authors);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Author a = db.Authors.Where(temp => temp.AuthorID == id).FirstOrDefault();
            return View(a);
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();        
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "AuthorName")] Author a)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(a);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        
        }


        public ActionResult Edit(int id)
        {
            Author existingAuthor = db.Authors.Where(temp => temp.AuthorID == id).FirstOrDefault();
            return View(existingAuthor);
        }

        [HttpPost]
        public ActionResult Edit(Author a)
        {
            Author existingAuthor = db.Authors.Where(temp => temp.AuthorID == a.AuthorID).FirstOrDefault();
            existingAuthor.AuthorName = a.AuthorName;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            Author existingAuthor= db.Authors.Where(temp => temp.AuthorID== id).FirstOrDefault();
            return View(existingAuthor);
        }
        [HttpPost]
        public ActionResult Delete(int id, Author a)
        {
            Author existingAuthor= db.Authors.Where(temp => temp.AuthorID == id).FirstOrDefault();
            db.Authors.Remove(existingAuthor);
            db.SaveChanges();
            return RedirectToAction("Index", "Authors");
        }
    }
}