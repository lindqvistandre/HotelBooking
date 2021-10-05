using DAL;
using REST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_API.Controllers
{
    public class RoomController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int hotelId)
        {
            try
            {
                using (HotelBookingEntities entities = new HotelBookingEntities())
                {
                    var hotels = entities.Rooms.Where(x => x.HotelId == hotelId)?.ToList();
                    if (hotels != null)
                    {
                        List<RoomModel> roomsCollection = new List<RoomModel>();

                        foreach (var item in hotels)
                        {
                            RoomModel model = new RoomModel();
                            model.Id = item.Id;
                            model.AvailableDate = item.AvailableDate;
                            model.HotelId = item.HotelId;
                            model.IsAvailable = item.IsAvailable;
                            model.PricePerNight = item.PricePerNight;
                            model.Size = item.Size;

                            roomsCollection.Add(model);
                        }
                        return Ok(roomsCollection);
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
