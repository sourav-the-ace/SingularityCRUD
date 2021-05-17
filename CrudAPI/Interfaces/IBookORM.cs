using CrudAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Interfaces
{
    interface IBookORM
    {
        public IEnumerable<BookModel> GetAllBookList();

        public IEnumerable<BookModel> GetBookById(string id);

        public int InsertBook(string name, string authorName, string genre);

        public int UpdateBook(int id, string name, string authorName, string genre);

        public int DeleteBook(int id);

        public IEnumerable<BookModel> GetAllTrashBookList();

        public int RecycleBook(int id);
    }
}
