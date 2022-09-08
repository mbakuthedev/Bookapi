using System;
using System.Collections.Generic;
using Bookapi.Models;
using MongoDB.Driver;

namespace Services
{
    public class Bookservices : IBookservices
    {
        private readonly IMongoCollection<Book> _books;
        
        public Bookservices(IBookstoreDbSettings settings)
        {
            var Client = new MongoClient(settings.ConnectionString);
            var database = Client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BookCollectionName);
                
        }

        public List<Book> GetBooks() =>
            _books.Find(book => true).ToList();

        public Book GetBook(string Id) =>
            _books.Find(book => book.Id == Id).FirstOrDefault();

        public Book Create(Book book) {
            _books.InsertOne(book);
           return book;
        }
        public void Update(string Id, Book book)
        {
            _books.ReplaceOne(book => book.Id == Id, book);
        }
        public void Delete(string Id) =>
            _books.DeleteOne(book => book.Id == Id);

        public void Delete(Book deletedbook) =>
            _books.DeleteOne(book => book.Id == deletedbook.Id);

       
    }
}
