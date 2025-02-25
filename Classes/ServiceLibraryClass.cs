using alexisRetry.Database_Connection;
using alexisRetry.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alexisRetry.Classes
{
    public static class ServiceLibraryClass
    {
        public static void LibLoader()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO D1.Services (Service, Tool, Fee_per_Hour) VALUES(@service, @tool, @feePhour)", connection))
                {
                    command.Parameters.AddWithValue("@service", ServiceLibraryObject.service);
                    command.Parameters.AddWithValue("@tool", ServiceLibraryObject.tool);
                    command.Parameters.AddWithValue("@feePhour", ServiceLibraryObject.fee);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Registered!");
                }
            }
        }
    }
}
