using CrudAPI.Configure;
using CrudAPI.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Models
{
    public class BookORM :IBookORM
    {
        public BookORM()
        {
            SqlMapper.AddTypeHandler(new TrimmedStringHandler());
            ConnectionManager conn = new ConnectionManager();
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionManager.connectionString);
            }
        }

        public IEnumerable<BookModel> GetAllBookList()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM LMS_BOOKS";
                dbConnection.Open();
                return dbConnection.Query<BookModel>(sQuery);
            }
        }

        public IEnumerable<BookModel> GetBookById(string id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    ID = id
                };
                string sQuery = @"SELECT * FROM LMS_BOOKS
                                WHERE ID=@ID";
                dbConnection.Open();
                var book = dbConnection.Query<BookModel>(sQuery, parm);
                return book;
            }
        }

        public int InsertBook(string name, string authorName, string genre)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    CallType = "INSERT",
                    BookName = name,
                    BookAuthorName = authorName,
                    BookGenre = genre
                };
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_BOOK_OPERATION", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }

        public int UpdateBook(int id, string name, string authorName, string genre)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    CallType = "UPDATE",
                    BookId = id,
                    BookName = name,
                    BookAuthorName = authorName,
                    BookGenre = genre
                };
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_BOOK_OPERATION", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }

        public int DeleteBook(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    CallType = "DELETE",
                    BookId = id
                };
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_BOOK_OPERATION", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }

        public IEnumerable<BookModel> GetAllTrashBookList()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM LMS_BOOKS_RECYCLE";
                dbConnection.Open();
                return dbConnection.Query<BookModel>(sQuery);
            }
        }

        public int RecycleBook(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    CallType = "RECYCLE",
                    BookId = id
                };
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_BOOK_OPERATION", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }
    }
}
