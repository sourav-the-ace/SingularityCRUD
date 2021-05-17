using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Configure
{
    public class ConnectionManager
    {
        public static string connectionString = "";
        public ConnectionManager()
        {
            //connectionString = GetConnectionString();
            connectionString = GetConnectionStringFromAppSetting();
        }

        public string GetConnectionStringFromAppSetting()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build().GetSection("ConnectionStrings").GetSection("ConnStr1").Value;
        }

        public string GetConnectionString()
        {
            connectionString = @"Data Source = SOURAVPC\SQLEXPRESS; Initial Catalog =LibraryMSDB;persist security info=True; Integrated Security=SSPI; ";
            return connectionString;
        }
    }
}
