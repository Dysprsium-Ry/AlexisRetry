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
        public static string[] GetServices()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT DISTINCT s.Service from D1.Services s JOIN D1.Tools t on t.Service = s.Service WHERE t.Quantity > 0", connection))
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
                using (SqlCommand command = new SqlCommand("SELECT DISTINCT s.Service FROM D1.Services s JOIN D1.Tools t on t.Service = s.Service WHERE t.Quantity > 0", connection))
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
                using (SqlCommand command = new SqlCommand("SELECT Tool, Quantity FROM D1.Tools WHERE Service = @service AND Quantity > 0", connection))
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
                using (SqlCommand command = new SqlCommand("SELECT Count(*) FROM D1.TransactionLogs WHERE CONVERT(DATE, ReservationDate) = Cast(@reserveDate AS DATE)", connection))
                {
                    command.Parameters.AddWithValue("@reserveDate", Objects.ServiceBooking.BookedDate == default(DateTime) ? (object)DBNull.Value : Objects.ServiceBooking.BookedDate);
                    //command.Parameters.AddWithValue("@userId", ClientObjects.ClientId);
                    //command.Parameters.AddWithValue("@service", Objects.ServiceBooking.Service ?? (object)DBNull.Value);

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
                    using (SqlCommand command = new SqlCommand("INSERT INTO D1.TransactionLogs (UserId, Username, Service, ReservationDate, TimeRender, pHourFee, PaymentStatus, TotalFee, DateBooked, EndDate, ToolsUsed) VALUES(@userId, @username, @service, @datebooked, @timerender, @pHourFee, @paymentstatus, @TotalFee, GetDate(), @endDate, @toolsUsed)", connection))
                    {
                        command.Parameters.AddWithValue("@userId", ClientObjects.ClientId);
                        command.Parameters.AddWithValue("@username", Objects.ServiceBooking.clientUsername);
                        command.Parameters.AddWithValue("@service", Objects.ServiceBooking.Service);
                        command.Parameters.AddWithValue("@datebooked", Objects.ServiceBooking.BookedDate);
                        command.Parameters.AddWithValue("@timerender", Objects.ServiceBooking.RentedDuration);
                        command.Parameters.AddWithValue("@pHourFee", Objects.ServiceBooking.HourlyRate);
                        command.Parameters.AddWithValue("@paymentStatus", "Pending");
                        command.Parameters.AddWithValue("@TotalFee", Objects.ServiceBooking.TotalFee);
                        command.Parameters.AddWithValue("@endDate", Objects.ServiceBooking.CalculatedDate);
                        command.Parameters.AddWithValue("@ToolsUsed", ToJson.Tools);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch { MessageBox.Show("Booking Failed, unexpected error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
        public static void ToolDecrement()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("UPDATE D1.Tools SET Quantity = Quantity - 1 WHERE Service = @service AND Quantity > 0", connection))
                {
                    command.Parameters.AddWithValue("@service", Objects.ServiceBooking.Service);
                    command.ExecuteNonQuery();
                }
            }
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
        public static void BookingToolsRegistration()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT Tool FROM D1.Tools WHERE Service = @service AND Quantity > 0", connection))
                {
                    command.Parameters.AddWithValue("@service", Objects.ServiceBooking.Service);

                    #region anotherWayAsTheySay
                    //List<string> tools = new List<string>();
                    //using (SqlDataReader reader = command.ExecuteReader())
                    //{
                    //    while (reader.Read())
                    //    {
                    //        tools.Add(reader.GetString(0));
                    //        ToolsList.ToolList.AddRange((IEnumerable<ToolsList>)tools);
                    //    }
                    //}
                    #endregion

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                ToolsList.ToolList.Add(new ToolsList { Tools = reader.GetString(0) });
                            }
                        }
                    }
                }
            }
        }
    }
}
