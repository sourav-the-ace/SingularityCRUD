using CrudAPI.Configure;
using CrudAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookORM books;
        public BookController()
        {
            books = new BookORM();
        }

        [HttpGet]
        public object GetAllBooks()
        {
            try
            {
                var result = books.GetAllBookList();
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpGet("{id}")]
        public object GetBookById(string id)
        {
            try
            {
                var result = books.GetBookById(id);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpPost]
        public object PostBookInfo(string name, string authorName, string genre)
        {
            try
            {
                var result = books.InsertBook(name, authorName, genre);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpPost]
        public object UpdateBookInfo(int id, string name, string authorName, string genre)
        {
            try
            {
                var result = books.UpdateBook(id, name, authorName, genre);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpPost]
        public object DeleteBookInfo(int id)
        {
            try
            {
                var result = books.DeleteBook(id);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpGet]
        public object GetAllTrashBooks()
        {
            try
            {
                var result = books.GetAllTrashBookList();
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpPost]
        public object RecycleBookInfo(int id)
        {
            try
            {
                var result = books.RecycleBook(id);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }
    }
}
