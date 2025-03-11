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
    public static class InventoryClass
    {
        public static void AddInventory()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO D1.Tools (Service, Tool, Quantity) VALUES(@service, @tool, @quantity)", connection))
                {
                    command.Parameters.AddWithValue("@service", InventoryObject.service);
                    command.Parameters.AddWithValue("@tool", InventoryObject.tool); 
                    command.Parameters.AddWithValue("@quantity", InventoryObject.quantity);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool IsToolExist()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM D1.Tools WHERE Service = @service AND Tool = @tool", connection))
                {
                    command.Parameters.AddWithValue("@service", InventoryObject.service);
                    command.Parameters.AddWithValue("@tool", InventoryObject.tool);
                    command.Parameters.AddWithValue("@quantity", InventoryObject.quantity);

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

        public static void InventoryDataGridProvider(DataGridView dataGridView)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT DISTINCT Tool, Quantity FROM D1.Tools WHERE Service = @service", connection))
                {
                    command.Parameters.AddWithValue("@service", InventoryObject.service);

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

        public static void SelectValueInventory(DataGridView dataGridView)
        {
            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

            //InventoryObject.service = selectedRow.Cells["Service"].Value.ToString();
            InventoryObject.tool = selectedRow.Cells["Tool"].Value.ToString();
            InventoryObject.quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value ?? 0);
        }

        public static void UpdateInventory()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("UPDATE D1.Tools SET Tool = @tool, Quantity = @quantity WHERE Service = @service AND Tool = @tool", connection))
                {
                    command.Parameters.AddWithValue("@service", InventoryObject.service);
                    command.Parameters.AddWithValue("@tool", InventoryObject.tool);
                    command.Parameters.AddWithValue("@quantity", InventoryObject.quantity);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteToolFromInventory()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM D1.Tools WHERE Service = @service AND Tool = @tool AND Quantity = @quantity", connection))
                {
                    command.Parameters.AddWithValue("@service", InventoryObject.service);
                    command.Parameters.AddWithValue("@tool", InventoryObject.tool);
                    command.Parameters.AddWithValue("@quantity", InventoryObject.quantity);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ToolManagement()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT T.ReservationDate, T.TimeRender, T.UserId, C.Username, C.PhoneNumber, T.LogId, T.Service, T.PaymentStatus, T.DateBooked FROM D1.TransactionLogs T INNER JOIN D1.Clients C ON T.UserId = C.ClientId WHERE DATEPART (WEEK,T.DateBooked) = DATEPART (WEEK,GETDATE()) AND DATEPART (YEAR,T.DateBooked) = DATEPART(YEAR, GETDATE()) ORDER BY T.DateBooked", connection))
                {

                }
            }
        }
    }
}
