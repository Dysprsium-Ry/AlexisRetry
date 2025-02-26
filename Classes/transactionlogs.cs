using alexisRetry.Database_Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alexisRetry.Classes
{
    public static class transactionlogs
    {
        public static void transactionlogsdGV(DataGridView dtgV)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM D1.TransactionLogs",connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dtgV.AutoGenerateColumns = true;
                        dtgV.DataSource = table;
                    }
                }
            }
        }
    }
}
