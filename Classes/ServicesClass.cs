using alexisRetry.Database_Connection;
using alexisRetry.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace alexisRetry.Classes
{
    public class ServicesClass
    {
        //public static void ServicesLoad()
        //{
        //    using (SqlConnection connection = DatabaseConnection.Establish())
        //    {
        //        using (SqlCommand command = new SqlCommand("SELECT Service FROM D1.Services", connection))
        //        {

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                List<string> services = new List<string>();
        //                while (reader.Read())
        //                {
        //                    if (!services.Contains(reader.GetString(0)))
        //                    {
        //                        services.Add(reader.GetString(0));
        //                    }
        //                }
        //                ServiceObjects.Service = services.ToArray();
        //            }
        //        }
        //    }
        //}
        public static string[] GetServices()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT Service FROM D1.Services", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> services = new List<string>();
                        while (reader.Read())
                        {
                            if (!services.Contains(reader.GetString(0)))
                            {
                                services.Add(reader.GetString(0));
                            }
                        }
                        ServiceObjects.Service = services.ToArray();
                        return services.ToArray();
                    }
                }
            }
        }

        public static void ViewServicesinService(DataGridView datagrid)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT DISTINCT Service FROM D1.Services", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        try
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            datagrid.AutoGenerateColumns = true;
                            datagrid.DataSource = table;
                        }
                        catch { }
                    }
                }
            }
        }
        public static void ViewToolsinService(DataGridView datagrid)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT Tool, Quantity FROM D1.Tools WHERE Service = @service", connection))
                {
                    command.Parameters.AddWithValue("@service", Objects.ServiceBooking.Service);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        try
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            datagrid.AutoGenerateColumns = true;
                            datagrid.DataSource = table;
                        }
                        catch { }
                    }
                }
            }
        }
        public static bool checkDate()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT Count(*) FROM D1.TransactionLogs WHERE DateBooked = @datebooked AND Service = @service", connection))
                {
                    command.Parameters.AddWithValue("@datebooked", Objects.ServiceBooking.BookedDate == default(DateTime) ? (object)DBNull.Value : Objects.ServiceBooking.BookedDate);
                    command.Parameters.AddWithValue("@userId", ClientObjects.ClientId);
                    command.Parameters.AddWithValue("@service", Objects.ServiceBooking.Service ?? (object)DBNull.Value);

                    int count = (command.ExecuteScalar() as int?) ?? 0;

                    return count > 0;
                }
            }
        }

        public static void ServiceBooking()
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.Establish())
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO D1.TransactionLogs (UserId, Username, Service, DateBooked, TimeRender, pHourFee, PaymentStatus, TotalFee) VALUES(@userId, @username, @service, @datebooked, @timerender, @pHourFee, @paymentstatus, @TotalFee)", connection))
                    {
                        command.Parameters.AddWithValue("@userId", ClientObjects.ClientId);
                        command.Parameters.AddWithValue("@username", Objects.ServiceBooking.clientUsername);
                        command.Parameters.AddWithValue("@service", Objects.ServiceBooking.Service);
                        command.Parameters.AddWithValue("@datebooked", Objects.ServiceBooking.BookedDate);
                        command.Parameters.AddWithValue("@timerender", Objects.ServiceBooking.RentedDuration);
                        command.Parameters.AddWithValue("@pHourFee", Objects.ServiceBooking.HourlyRate);
                        command.Parameters.AddWithValue("@paymentStatus", "Pending");
                        command.Parameters.AddWithValue("@TotalFee", Objects.ServiceBooking.TotalFee);
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch { MessageBox.Show("Booking Failed, unexpected error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
        public static void selectDataGridRow(DataGridView dataGirdView)
        {
            DataGridViewRow selectedRow = dataGirdView.SelectedRows[0];

            Objects.ServiceBooking.Service = selectedRow.Cells["Service"].Value.ToString();
        }
        public static void PriceFetcher()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT RatePerHour FROM D1.Services WHERE Service = @service", connection))
                {
                    command.Parameters.AddWithValue("@service", Objects.ServiceBooking.Service);

                    Objects.ServiceBooking.HourlyRate = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        public static void clientIdFetcher()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT ClientId FROM D1.Clients WHERE Username = @username", connection))
                {
                    command.Parameters.AddWithValue("@username", ServiceObjects.Clientusername);
                    ClientObjects.ClientId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
    }
}
