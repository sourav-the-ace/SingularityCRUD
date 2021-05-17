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
    public class AccessPolicyController : ControllerBase
    {
        private readonly AccessORM access;
        public AccessPolicyController()
        {
            access = new AccessORM();
        }

        [HttpPost]
        public object GrantInsertAccess(int id)
        {
            try
            {
                var result = access.GrantInsertAccess(id);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpPost]
        public object GrantUpdateAccess(int id)
        {
            try
            {
                var result = access.GrantUpdateAccess(id);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpPost]
        public object GrantDeleteAccess(int id)
        {
            try
            {
                var result = access.GrantDeleteAccess(id);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpPost]
        public object DenyInsertAccess(int id)
        {
            try
            {
                var result = access.DenyInsertAccess(id);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpPost]
        public object DenyUpdateAccess(int id)
        {
            try
            {
                var result = access.DenyUpdateAccess(id);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }

        [HttpPost]
        public object DenyDeleteAccess(int id)
        {
            try
            {
                var result = access.DenyDeleteAccess(id);
                return new ResponseResult { data = result, status = (int)Response.StatusCode, message = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseResult { data = ex.Message, status = (int)Response.StatusCode, message = "Failed" };
            }
        }
    }
}
