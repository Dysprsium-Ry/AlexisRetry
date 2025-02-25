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
    public class ServicesClass
    {
        public static void ViewToolsinService(DataGridView datagrid)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT Tool FROM D1.Services WHERE Service = @service", connection))
                {
                    command.Parameters.AddWithValue("@service", ServiceObjects.Service);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        datagrid.AutoGenerateColumns = true;
                        datagrid.DataSource = table;
                    }
                }
            }
        }

        public static void ServiceBooking()
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.Establish())
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO D1.TransactionLogs (UserID, Username, Service, DateBooked, TimeRender, pHourFee, PaymentStatus) VALUES(@userId, @username, @service, @datebooked, @timerender, @pHourFee, @paymentstatus)", connection))
                    {
                        command.Parameters.AddWithValue("@userId", ClientObjects.ClientId);
                        command.Parameters.AddWithValue("@username", ServiceObjects.Clientusername);
                        command.Parameters.AddWithValue("@service", ServiceObjects.Service);
                        command.Parameters.AddWithValue("@datebooked", ServiceObjects.BookedDate);
                        command.Parameters.AddWithValue("@timerender", ServiceObjects.HoursRented);
                        command.Parameters.AddWithValue("@pHourFee", ServiceObjects.Fee);
                        command.Parameters.AddWithValue("@paymentStatus", "Pending");
                        command.ExecuteNonQuery();

                        MessageBox.Show("Booked Succesfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch { ServiceValidator.BookingSuccess = false; }
        }
    }
}
