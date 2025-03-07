using alexisRetry.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace alexisRetry.Objects
{
    public class Objects
    {

    }

    #region service
    #endregion

    #region client
    #endregion

    #region ServiceLib
    #endregion

    #region transactionLogs
    #endregion

    public class ServiceObjects
    {
        public static string Clientusername { get; set; }
        public static string[] Service { get; set; }
        public static DateTime BookedDate { get; set; }
        public static int HoursRented { get; set; }
        public static int Fee { get; set; }
    }

    public class ServiceBooking
    {
        public static string clientUsername { get; set; }
        public static string Service { get; set; }
        public static DateTime BookedDate { get; set; }
        public static int RentedDuration { get; set; }
        public static int HourlyRate { get; set; }
        public static int TotalFee { get; set; }
        public static int OverallTotalFee { get; set; }
    }

    public class Booking
    {
        public string Service { get; set; }
        public DateTime BookedDate { get; set; }
        public int RentedDuration { get; set; }
        public int HourlyRate { get; set; }
        public int TotalFee { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Booking other = (Booking)obj;

            return Service == other.Service &&
                   BookedDate == other.BookedDate; //&&
                   //RentedDuration == other.RentedDuration &&
                   //HourlyRate == other.HourlyRate &&
                   //TotalFee == other.TotalFee;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Service?.GetHashCode() ?? 0);
                hash = hash * 23 + BookedDate.GetHashCode();
                //hash = hash * 23 + RentedDuration.GetHashCode();
                //hash = hash * 23 + HourlyRate.GetHashCode();
                //hash = hash * 23 + TotalFee.GetHashCode();
                return hash;
            }
        }
    }

    public class AdditionalBooking
    {
        public static List<Booking> TransactionsList = new List<Booking>();
        public static string Service { get; set; }
        public static DateTime BookedDate { get; set; }
        public static int RentedDuration { get; set; }
        public static int HourlyRate { get; set; }
        public static int TotalFee { get; set; }
    }

    public class ClientObjects
    {
        public static int ClientId { get; set; }
        public static string[] ClientUsername { get; set; }
    }

    public class ClientRegister
    {
        public static string username { get; set; }
        public static string email { get; set; }
        public static long PhoneNumber { get; set; }
        public static string name { get; set; }
    }

    public class ServiceLibraryObject
    {
        public static string service { get; set; }
        public static int HourlyRate { get; set; }
    }

    public class updateClientInfo
    {
        public static int id { get; set; }
        public static string username { get; set; }
        public static string email { get; set; }
        public static long phoneNum { get; set; }
        public static string name { get; set; }
    }

    public class transactionLogsObject
    {
        public static int logId { get; set; }
    }

    public class InventoryObject
    {
        public static string service { get; set; }
        public static string tool { get; set; }
        public static int quantity { get; set; }
    }

    public class BillingObject
    {
        public static int transactionId { get; set; }
        public static int clientId { get; set; }
        public static int serviceDuration { get; set; }
        public static int ratePerHour { get; set; }
        public static int totalFee { get; set; }
        public static string paymentStatus { get; set; }
    }

    public class ReportObjects
    {
        public static string service { get; set; }
        public static int totalFee { get; set; }
        public static int totalDuration { get; set; }
        public static int OverallTotalFee { get; set; }
    }

}
