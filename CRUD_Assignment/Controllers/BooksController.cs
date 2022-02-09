using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Assignment.Models;

namespace CRUD_Assignment.Controllers
{
    public class BooksController : Controller
    {
        CRUD_AssignmentEntities db = new CRUD_AssignmentEntities();

        // GET: Book
        public ActionResult Index(string search="", string SortColumn = "BookID", string IconClass = "fa-sort-asc", int PageNo = 1)
        {

            //Search
            ViewBag.search = search;
            List<Book> books = db.Books.Where(temp=> temp.BookName.Contains(search)||temp.Publication.Contains(search)||temp.Author.AuthorName.Contains(search)).ToList();
            
            ViewBag.Message = "Books Table";
            
            //Sorting
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            //Sorting by BookID
            if (ViewBag.SortColumn == "BookID")
            { 
                if(ViewBag.IconClass == "fa-sort-asc")
                {
                    books = books.OrderBy(temp => temp.BookID).ToList();
                }
                else
                {
                    books = books.OrderByDescending(temp => temp.BookID).ToList();
                }
            }

            //Sorting By BookName
            if (ViewBag.SortColumn == "BookName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    books = books.OrderBy(temp => temp.BookName).ToList();
                }
                else
                {
                    books = books.OrderByDescending(temp => temp.BookName).ToList();
                }
            }

            //Sorting By AuthorName
            if (ViewBag.SortColumn == "AuthorID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    books = books.OrderBy(temp => temp.AuthorID).ToList();
                }
                else
                {
                    books = books.OrderByDescending(temp => temp.AuthorID).ToList();
                }
            }

            //Sorting by ISBN
            if (ViewBag.SortColumn == "ISBN")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    books = books.OrderBy(temp => temp.ISBN).ToList();
                }
                else
                {
                    books = books.OrderByDescending(temp => temp.ISBN).ToList();
                }
            }

            //Sorting by Publication
            if (ViewBag.SortColumn == "Publication")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    books = books.OrderBy(temp => temp.Publication).ToList();
                }
                else
                {
                    books = books.OrderByDescending(temp => temp.Publication).ToList();
                }
            }

            //Sorting by Price
            if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    books = books.OrderBy(temp => temp.Price).ToList();
                }
                else
                {
                    books = books.OrderByDescending(temp => temp.Price).ToList();
                }
            }



            //Paging
            int RecordsPerPage = 4;
            int Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(books.Count)/Convert.ToDouble(RecordsPerPage)));
            int RecordsToSkip = (PageNo - 1) * RecordsPerPage;

            ViewBag.PageNo = PageNo;
            ViewBag.Pages = Pages;

            books = books.Skip(RecordsToSkip).Take(RecordsPerPage).ToList();
            return View(books);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Book b = db.Books.Where(temp => temp.BookID == id).FirstOrDefault();
            return View(b);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Authors = db.Authors.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book b)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgByteArray = new Byte[file.ContentLength];
                    file.InputStream.Read(imgByteArray, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgByteArray);
                    b.Image = base64String;
                }
                db.Books.Add(b);
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
            Book existingBook = db.Books.Where(temp => temp.BookID == id).FirstOrDefault();
            ViewBag.Authors = db.Authors.ToList();
            return View(existingBook);
        }

        [HttpPost]
        public ActionResult Edit(Book b)
        {
            Book existingBook = db.Books.Where(temp => temp.BookID == b.BookID).FirstOrDefault();
            existingBook.ISBN = b.ISBN;
            existingBook.BookName = b.BookName;
            existingBook.AuthorID = b.AuthorID;
            existingBook.Publication = b.Publication;
            existingBook.Price = b.Price;
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgByteArray = new byte[file.ContentLength];
                file.InputStream.Read(imgByteArray, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imgByteArray);
                b.Image = base64String;
                existingBook.Image = b.Image;
                 
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            Book existingBook = db.Books.Where(temp => temp.BookID == id).FirstOrDefault();
            return View(existingBook);
        }
        [HttpPost]
        public ActionResult Delete(int id, Book b)
        {
            Book existingBook = db.Books.Where(temp => temp.BookID == id).FirstOrDefault();
            db.Books.Remove(existingBook);
            db.SaveChanges();
            return RedirectToAction("Index", "Books");
        }
    }
}