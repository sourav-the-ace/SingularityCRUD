using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string USER_ID { get; set; }
        public string FULL_NAME { get; set; }
        public string USER_EMAIL { get; set; }
        public string USER_LOGIN_NAME { get; set; }
        public string USER_LOGIN_PASS { get; set; }
        public string USER_TYPE { get; set; }
    }
}
