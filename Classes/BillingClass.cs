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
                using (SqlCommand command = new SqlCommand("SELECT LogId, Username, Service, ReservationDate, TimeRender, TotalFee, PaymentStatus, DateBooked FROM D1.TransactionLogs WHERE PaymentStatus <> 'Paid' AND ReservationDate >= GetDate();", connection))
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

            BillingObject.transactionId = Convert.ToInt32(selectedRow.Cells["LogId"].Value ?? 0);
            BillingObject.username = selectedRow.Cells["Username"].Value.ToString();
        }

        public static void ApprovePayment()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("UPDATE D1.TransactionLogs SET PaymentStatus = 'Paid' WHERE LogId = @logId", connection))
                {
                    command.Parameters.AddWithValue("@logId", BillingObject.transactionId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void RegisteredApprovedPayment(DataGridView dataGridView)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT T.LogId, T.DateBooked, T.TimeRender, T.Service, C.ClientId, C.Username, C.PhoneNumber, T.PaymentStatus FROM D1.TransactionLogs T INNER JOIN D1.Clients C ON C.ClientId = T.UserId WHERE T.PaymentStatus = 'Paid';", connection))
                {

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
    }
}
