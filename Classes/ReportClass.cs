using alexisRetry.Database_Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;
using alexisRetry.Objects;

namespace alexisRetry.Classes
{
    public static class ReportClass
    {
        public static void SetReportData(ReportViewer reportViewer)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT LogId, Username, Service, DateBooked, TimeRender, pHourFee, TotalFee, PaymentStatus FROM D1.TransactionLogs WHERE LogId = @logId", connection))
                {
                    command.Parameters.AddWithValue("@logId", BillingObject.transactionId);

                    DataTable dataset = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataset);

                    reportViewer.LocalReport.DataSources.Clear();

                    ReportDataSource reportDataSource = new ReportDataSource("DataSet2", dataset);
                    ReportParameter custName = new ReportParameter("CustomerName", ServiceBooking.clientUsername);
                    ReportParameter dateBooked = new ReportParameter("DateBooked", Objects.ServiceBooking.Service);
                    reportViewer.LocalReport.ReportPath = "AlexisRetryReport.rdlc";
                    reportViewer.LocalReport.DataSources.Add(reportDataSource);
                    reportViewer.LocalReport.SetParameters(custName);

                    reportViewer.RefreshReport();
                    reportViewer.Refresh();
                }
            }
        }
    }
}
