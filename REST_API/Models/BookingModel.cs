using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public Nullable<int> RoomId { get; set; }
        public Nullable<int> HotelId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> BookingDays { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<double> TotalCharges { get; set; }
        public string Extras { get; set; }

        public virtual CustomerModel Customer { get; set; }
        public virtual HotelInfoModel HotelInfo { get; set; }
        public virtual RoomModel Room { get; set; }
    }
}