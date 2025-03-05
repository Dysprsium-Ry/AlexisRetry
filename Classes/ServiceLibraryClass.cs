using alexisRetry.Database_Connection;
using alexisRetry.Objects;
using System;
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
        public static bool IsDoesNotExist()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM D1.Services WHERE Service = @service", connection))
                {
                    command.Parameters.AddWithValue("@service", ServiceLibraryObject.service);

                    object result = command.ExecuteScalar();

                    if (result == null || Convert.ToInt32(result) == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public static void ServiceLib(DataGridView dataGrid)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT DISTINCT Service, RatePerHour FROM D1.Services", connection))
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

        public static void SelectValueUpdateService(DataGridView dataGridView)
        {
            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

            ServiceLibraryObject.service = selectedRow.Cells["Service"].Value.ToString();
            ServiceLibraryObject.HourlyRate = Convert.ToInt32(selectedRow.Cells["RatePerHour"].Value ?? 0);
        }

        public static void UpdateService()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("UPDATE D1.Services SET Service = @service, RatePerHour = @RatePerHour WHERE Service = @service", connection))
                {
                    command.Parameters.AddWithValue("@service", ServiceLibraryObject.service);
                    command.Parameters.AddWithValue("@RatePerHour", ServiceLibraryObject.HourlyRate);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static void DeleteService()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM D1.Services WHERE Service = @service", connection))
                {
                    command.Parameters.AddWithValue("@service", ServiceLibraryObject.service);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
