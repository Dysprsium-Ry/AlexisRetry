using alexisRetry.Database_Connection;
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
    public static class WeeklyScheduleClass
    {
        public static void WeeklyScheduleDataGridProvider(DataGridView dataGridView)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT T.DateBooked, T.TimeRender, T.UserId, C.Username, C.PhoneNumber, T.LogId, T.Service, T.PaymentStatus FROM D1.TransactionLogs T INNER JOIN D1.Clients C ON T.UserId = C.ClientId WHERE DATEPART (WEEK,T.DateBooked) = DATEPART (WEEK,GETDATE()) AND DATEPART (YEAR,T.DateBooked) = DATEPART(YEAR, GETDATE()) ORDER BY T.DateBooked", connection))
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
