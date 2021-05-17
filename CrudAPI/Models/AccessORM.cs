using CrudAPI.Configure;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Models
{
    public class AccessORM
    {
        public AccessORM()
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

        public IEnumerable<AccessModel> GetAllUserAccessList()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM LMS_ACCESS_POLICY";
                dbConnection.Open();
                return dbConnection.Query<AccessModel>(sQuery);
            }
        }

        public int GrantInsertAccess(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    CallType = "GRANT_INSERT",
                    Id = id
                };
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_ACCESS_POLICTY", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }
        public int GrantUpdateAccess(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    CallType = "GRANT_UPDATE",
                    Id = id
                };
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_ACCESS_POLICTY", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }
        public int GrantDeleteAccess(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    CallType = "GRANT_DELETE",
                    Id = id
                };
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_ACCESS_POLICTY", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }
        public int DenyInsertAccess(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    CallType = "DENY_INSERT",
                    Id = id
                };
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_ACCESS_POLICTY", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }
        public int DenyUpdateAccess(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    CallType = "DENY_UPDATE",
                    Id = id
                };
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_ACCESS_POLICTY", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }
        public int DenyDeleteAccess(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                var parm = new
                {
                    CallType = "DENY_DELETE",
                    Id = id
                };
                dbConnection.Open();
                int recordsAffected = dbConnection.Execute("dbo.SP_ACCESS_POLICTY", parm, commandType: CommandType.StoredProcedure);
                return recordsAffected;
            }
        }

    }
}
