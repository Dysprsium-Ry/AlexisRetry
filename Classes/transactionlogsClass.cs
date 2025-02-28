using alexisRetry.Database_Connection;
using alexisRetry.Objects;
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
    public static class transactionlogsClass
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
        public static void selectDataGridRow(DataGridView dataGirdView)
        {
            DataGridViewRow selectedRow = dataGirdView.SelectedRows[0];

            transactionLogsObject.logId = Convert.ToInt32(selectedRow.Cells["LogId"].Value);
        }
        public static void DeleteLog()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM D1.TransactionLogs WHERE LogId = @logId", connection))
                {
                    command.Parameters.AddWithValue("@logId", transactionLogsObject.logId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
