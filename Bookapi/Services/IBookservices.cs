using Bookapi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
   public interface IBookservices
    {
        List<Book> GetBooks();

        Book GetBook(string Id);

        Book Create(Book book);
        void Update(string Id,Book book);
        void Delete(string Id);
        void Delete(Book book);
    }
}
