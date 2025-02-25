using alexisRetry.Database_Connection;
using alexisRetry.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace alexisRetry.Classes
{
    public static class ClientClass
    {
        public static void ClientsList()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM D1.Clients", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> clientusernames = new List<string>();
                        while (reader.Read())
                        {
                            clientusernames.Add(reader.GetString(1));
                        }
                        ClientObjects.ClientUsername = clientusernames.ToArray();
                    }
                }
            }
        }

        public static void ClientIdList()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT ClientId FROM D1.Clients WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", ClientObjects.ClientUsername);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ClientObjects.ClientId = reader.GetInt32(0);
                    }
                }
            }
        }
    }
}
