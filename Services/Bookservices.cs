using System;
using MongoDB.Driver;

namespace Services
{
    public class Bookservices 
    {
        private readonly IMongoCollection<Book> _books;
        public Bookservices(BookstoreDbSettings settings)
        {

                
        }

    }
}
