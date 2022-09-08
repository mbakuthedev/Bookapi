using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookapi.Models
{
    public class BookstoreDbSettings : IBookstoreDbSettings
    {
        public string BookCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
