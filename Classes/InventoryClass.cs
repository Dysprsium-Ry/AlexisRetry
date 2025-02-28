using alexisRetry.Database_Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alexisRetry.Classes
{
    public static class InventoryClass
    {
        public static void AddInventory()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO D1.Services ()", connection))
                {

                }
            }
        }
    }
}
