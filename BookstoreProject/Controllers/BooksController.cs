using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookstoreProject.Models;

namespace BookstoreProject.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private BookDBContext db = new BookDBContext();

        /// <summary>
        /// ActionResult which returns a index of Books
        /// </summary>
        /// <returns>
        /// The list of Books
        /// </returns>
        
        // GET: Books

        public ActionResult Index()
        {
            
            return View(db.Books.ToList());
        }
        /// <summary>
        /// Details which returns an a View of individual book details
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Status code if id is null
        /// if there is no book associated with the given id and HTTPNotFound will be returned
        /// else details of a book will be returned
        /// </returns>
        // GET: Books/Details/5
        public ActionResult Details(int? id)
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
        /// <summary>
        /// Create method with return type ActionResult
        /// </summary>
        /// <returns>
        /// Returns a create view
        /// </returns>
        // GET: Books/Create
        
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Saves the creation of a book to database
        /// </summary>
        /// <param name="book"></param>
        /// <returns>
        /// If model is valid 
        /// redirects to index action
        /// else redisplay the current view with the same book object.
        /// </returns>
        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "ID,Title,Author,Price,ReleaseDate")] Book book)
        {
            if (ModelState.IsValid)
            {
                Debug.WriteLine("Object created " + book.ToString());
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }
        /// <summary>
        /// Allows editing of a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Status code if id is null
        /// if there is no book associated with the given id and HTTPNotFound will be returned
        /// else a view will return with the given book
        /// </returns>
        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
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

        /// <summary>
        /// Edit method which returns an ActionResult
        /// </summary>
        /// <param name="book"></param>
        /// <returns>
        /// If model is valid 
        /// redirects to index action
        /// else redisplay the current view with the same book object.
        /// </returns>
        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Author,Price,ReleaseDate")] Book book)
        {
            if (ModelState.IsValid)
            {
                Debug.WriteLine("Object edited " + book.ToString());
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        /// <summary>
        ///  Delete to remove the specfied book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Status code if id is null
        /// if there is no book associated with the given id and HTTPNotFound will be returned
        /// else a view will return with the given book
        /// </returns>
        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
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

        /// <summary>
        /// Confirms deletion of a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Redirection to index action
        /// </returns>
        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            Debug.WriteLine("Object deleted " + book.ToString());
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
