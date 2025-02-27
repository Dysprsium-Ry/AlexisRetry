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
        public static void ServicesLoad()
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
                    }
                }
            }
        }

        public static void ViewToolsinService(DataGridView datagrid)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT Tool FROM D1.Services WHERE Service = @service", connection))
                {
                    command.Parameters.AddWithValue("@service", serviceBooking.Service);

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

        public static void ServiceBooking()
        {
            int total = serviceBooking.Fee * serviceBooking.HoursRented;
            try
            {
                using (SqlConnection connection = DatabaseConnection.Establish())
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO D1.TransactionLogs (ClientId, Username, Service, DateBooked, TimeRender, pHourFee, PaymentStatus, TotalFee) VALUES(@userId, @username, @service, @datebooked, @timerender, @pHourFee, @paymentstatus, @TotalFee)", connection))
                    {
                        command.Parameters.AddWithValue("@userId", ClientObjects.ClientId);
                        command.Parameters.AddWithValue("@username",serviceBooking.clientUsername);
                        command.Parameters.AddWithValue("@service",serviceBooking.Service);
                        command.Parameters.AddWithValue("@datebooked",serviceBooking.BookedDate);
                        command.Parameters.AddWithValue("@timerender", serviceBooking.HoursRented);
                        command.Parameters.AddWithValue("@pHourFee",serviceBooking.Fee);
                        command.Parameters.AddWithValue("@paymentStatus", "Pending");
                        command.Parameters.AddWithValue("@TotalFee", total);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Booked Succesfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch { ServiceValidator.BookingSuccess = false; }
        }
        
        //public static void AddServicetoLib()
        //{
        //    using (SqlConnection connection = DatabaseConnection.Establish())
        //    {
        //        using (SqlCommand command = new SqlCommand("INSERT INTO D1.Services (Service, Fee_per_Hour) VALUES (@Service, @FeePHour)", connection))
        //        {
        //            command.Parameters.AddWithValue("@Service", serviceBooking.Service);
        //            command.Parameters.AddWithValue("@FeePHour", serviceBooking.Fee);
        //        }
        //    }
        //}
    }
}
