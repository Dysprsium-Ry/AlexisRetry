using alexisRetry.Database_Connection;
using alexisRetry.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alexisRetry.Classes
{
    public static class BillingClass
    {
        public static void BillingStatementDataGridProvider(DataGridView dataGridView)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM D1.TransactionLogs", connection))
                {
                    //command.Parameters.AddWithValue("@service", InventoryObject.service);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView.AutoGenerateColumns = true;
                        dataGridView.DataSource = table;
                    }
                }
            }
        }

        public static void selectDataGridRow(DataGridView dataGirdView)
        {
            DataGridViewRow selectedRow = dataGirdView.SelectedRows[0];

            Objects.ServiceBooking.Service = selectedRow.Cells["LogId"].Value.ToString();
        }

        public static void ApprovePayment()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("UPDATE D1.TransactionLogs SET PaymentStatus = 'Paid' WHERE LogId = @logId", connection))
                {
                    command.Parameters.AddWithValue("@logId", Objects.ServiceBooking.Service);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
