using Bookapi.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bookapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookstoreController : ControllerBase
    {
        private readonly IBookservices _bookService;
        private readonly IBookstoreDbSettings _bookstoreDbSettings;
        BookstoreController(IBookservices bookService,IBookstoreDbSettings bookstoreDbSettings)
        {
            _bookService = bookService;
            _bookstoreDbSettings = bookstoreDbSettings;
           
        }

        // GET: api/<BookstoreController>
        [HttpGet]
        public ActionResult<List<Book>> GetBooks() =>
            _bookService.GetBooks(); 
       
   
        // GET api/<BookstoreController>/5
        [HttpGet("{id}", Name = "Getbook")]
        public ActionResult<Book> GetBook(string id)
        {
            var book = _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
                
            }
            return book;
        }

        // POST api/<BookstoreController>
        [HttpPost]
        public ActionResult<Book> Post (Book book)
        {
            _bookService.Create(book);
            return CreatedAtRoute("Get", new {Id = book.Id.ToString()});
        }

        // PUT api/<BookstoreController>/5
        [HttpPut("{id}")]
        public ActionResult<Book> Put(string id, Book book)
        {
            var updatedBook = _bookService.GetBook(id);
            if (book == null)
            {
                return NoContent();
            }
            _bookService.Update(id, book);
            return updatedBook;
        }

        // DELETE api/<BookstoreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.GetBook(id);
            if (book ==  null)
            {
                return NotFound();
            }
            _bookService.Delete(id);
            return NoContent();
        }
    }
}
