using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alexisRetry.Objects
{
    public class ServiceObjects
    {
        public static string Clientusername { get; set; }
        public static string Service { get; set; }
        public static DateTime BookedDate { get; set; }
        public static int HoursRented { get; set; }
        public static int Fee { get; set; }
        //public static List<ServiceObjects> Services { get; set; }
    }

    public class ServiceValidator
    {
        public static bool BookingSuccess { get; set; }
    }
}
