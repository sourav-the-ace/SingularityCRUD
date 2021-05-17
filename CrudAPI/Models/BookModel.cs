using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Models
{
    public class BookModel
    {
        public int ID { get; set; }
        public string BOOK_ID { get; set; }
        public string BOOK_NAME { get; set; }
        public string BOOK_AUTHOR_NAME { get; set; }
        public string BOOK_GENRE { get; set; }
    }
}
