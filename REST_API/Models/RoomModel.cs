using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public Nullable<int> HotelId { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<System.DateTime> AvailableDate { get; set; }
        public string Size { get; set; }
        public Nullable<double> PricePerNight { get; set; }
        public virtual ICollection<BookingModel> Bookings { get; set; }
        public virtual HotelInfoModel HotelInfo { get; set; }
    }
}