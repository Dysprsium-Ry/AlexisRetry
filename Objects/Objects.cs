using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class ServiceValidator
    {
        public static bool BookingSuccess { get; set; }
    }

    public class serviceBooking
    {
        public static string clientUsername { get; set; }
        public static string Service { get; set; }
        public static DateTime BookedDate { get; set; }
        public static int HoursRented { get; set; }
        public static int Fee { get; set; }
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
        public static string tool { get; set; }
        public static int fee { get; set; }
    }

    public class updateClientInfo
    {
        public static int id { get; set; }
        public static string username { get; set; }
        public static string email { get; set; }
        public static long phoneNum { get; set; }
        public static string name { get; set; }
    }
}
