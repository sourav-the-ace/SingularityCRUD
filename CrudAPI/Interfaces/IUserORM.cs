using CrudAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Interfaces
{
    interface IUserORM
    {
        public IEnumerable<UserModel> GetAllUserList();

        public IEnumerable<UserModel> GetUserById(string id);

        public IEnumerable<UserModel> Login(string name, string pass);

        public int InsertUser(string name, string email, string loginName, string loginPass, string userType);

        public int UpdateUser(int id, string name, string email, string loginName);

        public int DeleteUser(int id);

        public IEnumerable<UserModel> GetAllTrashUserList();

        public int RecycleUser(int id);
    }
}
