using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Common
{
    static class Global
    {
        private static Customer _loggeduser = null;

        public static Customer Loggeduser
        {
            get { return _loggeduser; }
            set { _loggeduser = value; }
        }
    }
}
