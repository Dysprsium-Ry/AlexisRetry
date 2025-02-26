using alexisRetry.Database_Connection;
using alexisRetry.Objects;
using System.Data;
using System.Data.SqlClient;
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

        public static void ServiceLib(DataGridView dataGrid)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                if (ServiceLibraryObject.service != null)
                {
                    using (SqlCommand command = new SqlCommand("SELECT Tool FROM D1.Services WHERE Service = @service", connection))
                    {
                        command.Parameters.AddWithValue("@service", ServiceLibraryObject.service);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            dataGrid.AutoGenerateColumns = true;
                            dataGrid.DataSource = table;
                        }
                    }
                }
                else
                {
                    using (SqlCommand command = new SqlCommand("SELECT Tool FROM D1.Services", connection))
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
