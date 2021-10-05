using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models
{
    public class ExtraModel
    {
        public int Id { get; set; }
        public string ExtraDescription { get; set; }
        public Nullable<int> HotelId { get; set; }

        public virtual HotelInfoModel HotelInfo { get; set; }
    }
}