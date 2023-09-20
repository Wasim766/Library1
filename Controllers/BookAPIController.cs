using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Library.Models; 

namespace Library.Controllers
{
    [RoutePrefix("api/BookAPI")]
    public class BookAPIController : ApiController
    {
        private LibraryDbContext db = new LibraryDbContext();


        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return db.Books.ToList();
        }

        // GET api/BookAPI/5
        public IHttpActionResult Get(int id)
        {
            var book = db.Books.FirstOrDefault(b => b.BookID == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

      
    }
}
