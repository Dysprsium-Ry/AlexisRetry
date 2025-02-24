using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alexisRetry.Database_Connection
{
    public static class Database
    {
        public static string Connectionstring => ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
    }

    public static class DatabaseConnection
    {
        public static SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(Database.Connectionstring);
            connection.Open();
            return connection;
        }
    }
}
