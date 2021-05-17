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
    public class UserORM :IUserORM
    {
        public UserORM()
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

        public IEnumerable<UserModel> GetAllUserList()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM LMS_USERS";
                dbConnection.Open();
                return dbConnection.Query<UserModel>(sQuery);
            }
        }

        public IEnumerable<UserModel> GetUserById(string id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    ID = id
                };
                string sQuery = @"SELECT * FROM LMS_USERS 
                                WHERE ID=@ID";
                dbConnection.Open();
                var user = dbConnection.Query<UserModel>(sQuery,parm);
                return user;
            }
        }

        public IEnumerable<UserModel> Login(string name,string pass)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    USER_LOGIN_NAME = name,
                    USER_LOGIN_PASS=pass
                };
                string sQuery = @"SELECT * FROM LMS_USERS 
                                WHERE USER_LOGIN_NAME=@USER_LOGIN_NAME AND USER_LOGIN_PASS=@USER_LOGIN_PASS";
                dbConnection.Open();
                var user = dbConnection.Query<UserModel>(sQuery, parm);
                return user;
            }
        }

        public int InsertUser(string name,string email,string loginName,string loginPass, string userType)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new DynamicParameters();
                parm.Add("@CallType", "INSERT",DbType.String,ParameterDirection.Input);
                parm.Add("@UserId");
                parm.Add("@UserName", name, DbType.String, ParameterDirection.Input);
                parm.Add("@UserEmail", email, DbType.String, ParameterDirection.Input);
                parm.Add("@UserLoginName", loginName, DbType.String, ParameterDirection.Input);
                parm.Add("@UserPass",loginPass, DbType.String, ParameterDirection.Input);
                parm.Add("@UserType", userType, DbType.String, ParameterDirection.Input);
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_USER_OPERATION", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }

        public int UpdateUser(int id,string name, string email, string loginName)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    CallType = "UPDATE",
                    UserId=id,
                    UserName = name,
                    UserEmail = email,
                    UserLoginName = loginName
                    //,
                    //UserPass = loginPass,
                    //UserType = userType
                };
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_USER_OPERATION", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }

        public int DeleteUser(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    CallType = "DELETE",
                    UserId = id
                };
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_USER_OPERATION", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }

        public IEnumerable<UserModel> GetAllTrashUserList()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM LMS_USERS_RECYCLE";
                dbConnection.Open();
                return dbConnection.Query<UserModel>(sQuery);
            }
        }

        public int RecycleUser(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    CallType = "RECYCLE",
                    UserId = id
                };
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_USER_OPERATION", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }
    }
}
