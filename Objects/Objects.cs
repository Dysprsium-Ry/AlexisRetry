using alexisRetry.Classes;
using System;

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
    public class multipleBookings
    {
        public static string Service1 { get; set; }
        public static string Service2 { get; set; }

        public static int Fee1 { get; set; }
        public static int Fee2 { get; set; }

        public static int time1 { get; set; }
        public static int time2 { get; set; }

        public static int totalFee1 { get; set; }
        public static int totalFee2 { get; set; }
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
}
