using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Configure
{
    public class ResponseResult
    {
        public string timestamp { get; set; } = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        public int status { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
