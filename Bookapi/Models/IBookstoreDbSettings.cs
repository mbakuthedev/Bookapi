using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookapi.Models
{
    public interface IBookstoreDbSettings
    {
         string BookCollectionName { get; set; }
         string ConnectionString { get; set; }
         string DatabaseName { get; set; }
    }
}
