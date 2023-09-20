using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private LibraryDbContext db = new LibraryDbContext();

        // GET: Library
        public ActionResult Index()
        {
            var author = db.Authors.ToList();
            return View(author);
        }

        [HttpGet]
        public ActionResult GetBooksByAuthor(int AuthorId)
        {
            var books = db.GetBooksByAuthor(AuthorId);

            return Json(books, JsonRequestBehavior.AllowGet);
        }

       
    }
}