using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alexisRetry.Objects
{
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
}
