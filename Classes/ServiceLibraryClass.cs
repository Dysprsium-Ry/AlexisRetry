using alexisRetry.Database_Connection;
using alexisRetry.Objects;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace alexisRetry.Classes
{
    public static class ServiceLibraryClass
    {
        public static void AddService()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO D1.Services (Service, RatePerHour) VALUES(@service, @RatePerHour)", connection))
                {
                    command.Parameters.AddWithValue("@service", ServiceLibraryObject.service);
                    command.Parameters.AddWithValue("@RatePerHour", ServiceLibraryObject.HourlyRate);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Saved Successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static void ServiceLib(DataGridView dataGrid)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                if (ServiceLibraryObject.service != null)
                {
                    using (SqlCommand command = new SqlCommand("SELECT DISTINCT Service FROM D1.Services", connection))
                    { 
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            dataGrid.AutoGenerateColumns = true;
                            dataGrid.DataSource = table;
                        }
                    }
                }
            }
        }
    }
}
