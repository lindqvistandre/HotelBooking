using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models
{
    public class HotelInfoModel
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public Nullable<double> Rating { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Nullable<int> NumberOfRooms { get; set; }
        public Nullable<bool> HasPrizes { get; set; }
        public Nullable<bool> IsAvailable { get; set; }

        public virtual ICollection<BookingModel> Bookings { get; set; }
        public virtual ICollection<RoomModel> Rooms { get; set; }
    }
}