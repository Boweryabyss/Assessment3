using BookstoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookstoreProject.Controllers
{
    public class HomeController : Controller
    {
        private BookDBContext db = new BookDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// The store Method uses a ActionResult type which will return a view based upon the sortType, 
        /// the sortType will determine whether the list of books is sorted by Price ascending or descending, or 
        /// release date of latest releases
        /// </summary>
        /// <returns>List from dbSet if sortType is null 
        /// else returns a sorted list based upon the sortType received from the Request</returns>
        public ActionResult Store()
        {
            int? sortType = Convert.ToInt32(Request.Form["Sort by"]);
            if (sortType.Equals(null))
            {
                return View(db.Books.ToList());
            }

            var books = from s in db.Books select s;

            switch (sortType)
            {
                case 1: books = books.OrderByDescending(b => b.Price);
                    break;
                case 2: books = books.OrderBy(b => b.Price);
                    break;
                case 3: books = books.OrderByDescending(b => b.ReleaseDate);
                    break;
            }

            return View(books.ToList());
        }
        /// <summary>
        /// Displaying of a product page of a given Book
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Error message id id is null or if a book object received is null else it will return a view with a book with
        /// the associated id</returns>
        public ActionResult ProductPage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        
    }
}