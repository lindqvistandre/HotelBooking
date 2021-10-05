using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_API.Models
{
    public class HotelController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                using (HotelBookingEntities entities = new HotelBookingEntities())
                {
                    var hotels = entities.HotelInfoes.ToList();
                    if (hotels != null)
                    {
                        List<HotelInfoModel> hotelsCollection = new List<HotelInfoModel>();

                        foreach (var item in hotels)
                        {
                            HotelInfoModel model = new HotelInfoModel();
                            model.Id = item.Id;
                            model.HasPrizes = item.HasPrizes;
                            model.HotelName = item.HotelName;
                            model.IsAvailable = item.IsAvailable;
                            model.NumberOfRooms = item.NumberOfRooms;
                            model.Rating = item.Id;
                            model.Country = item.Country;
                            model.City = item.City;

                            hotelsCollection.Add(model);
                        }
                        return Ok(hotelsCollection);
                    }
                    else
                    {
                        return Content(HttpStatusCode.NotFound, "No Hotels Available");
                    }


                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);

            }
        }
    }
}
