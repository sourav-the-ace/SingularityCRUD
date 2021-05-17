using CrudAPI.Configure;
using CrudAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrudAPI.Controllers
{


    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserORM users;
        public UserController()
        {
            users = new UserORM();
        }
        [HttpGet]
        public object GetAllUser()
        {            
            try
            {
                var result = users.GetAllUserList();
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }

        }

        [HttpGet("{id}")]
        public object GetUserById(string id)
        {
            try
            {
                var result = users.GetUserById(id);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch(Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpGet("{name}/{pass}")]
        public object Login(string name,string pass)
        {
            try
            {
                var result = users.Login(name, pass);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpPost]
        public object PostUserInfo(string name, string email, string loginName, string loginPass, string userType)
        {
            try
            {
                var result =users.InsertUser(name, email, loginName, loginPass, userType);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpPost]
        public object UpdateUserInfo(int id,string name, string email, string loginName)
        {
            try
            {
                var result = users.UpdateUser(id, name, email, loginName);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpPost]
        public object DeleteUserInfo(int id)
        {
            try
            {
                var result = users.DeleteUser(id);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpGet]
        public object GetAllTrashUser()
        {
            try
            {
                var result = users.GetAllTrashUserList();
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }

        }

        [HttpPost]
        public object RecycleUserInfo(int id)
        {
            try
            {
                var result = users.RecycleUser(id);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }
    }
}
