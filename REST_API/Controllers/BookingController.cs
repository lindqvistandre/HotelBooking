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
    public class BookingController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int userId)
        {
            try
            {
                using (HotelBookingEntities entities = new HotelBookingEntities())
                {
                    var bookings = entities.Bookings.Where(x => x.CustomerId == userId)?.ToList();
                    if (bookings != null)
                    {
                        List<BookingModel> bookingsCollection = new List<BookingModel>();

                        foreach (var item in bookings)
                        {
                            BookingModel model = new BookingModel();
                            model.Id = item.Id;
                            model.EndDate = item.EndDate;
                            model.HotelId = item.HotelId;
                            model.HotelInfo = new HotelInfoModel() { HotelName = item.HotelInfo.HotelName };
                            model.StartDate = item.StartDate;
                            model.BookingDays = item.BookingDays;
                            model.CustomerId = item.CustomerId;
                            model.RoomId = item.RoomId;
                            model.Extras = item.Extras;
                            model.TotalCharges = item.TotalCharges;

                            bookingsCollection.Add(model);
                        }
                        return Ok(bookingsCollection);
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
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Booking booking)
        {
            try
            {
                using (HotelBookingEntities entities = new HotelBookingEntities())
                {
                    entities.Bookings.Add(booking);
                    entities.SaveChanges();

                    var room = entities.Rooms.Find(booking.RoomId);
                    room.IsAvailable = false;
                    entities.SaveChanges();

                    var res = Request.CreateResponse(HttpStatusCode.Created, booking);
                    res.Headers.Location = new Uri(Request.RequestUri + booking.Id.ToString());
                    return res;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int bookingId)
        {
            try
            {
                using (HotelBookingEntities entities = new HotelBookingEntities())
                {
                    var booking = entities.Bookings.Where(emp => emp.Id == bookingId).FirstOrDefault();
                    if (booking != null)
                    {
                        var room = entities.Rooms.Find(booking.RoomId);
                        room.IsAvailable = true;

                        entities.Bookings.Remove(booking);


                     
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "booking with id" + bookingId + " Deleted");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "booking with id" + bookingId + " is not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody] Booking booking)
        {
            try
            {
                using (HotelBookingEntities entities = new HotelBookingEntities())
                {
                    var b = entities.Bookings.Where(em => em.Id == booking.Id).FirstOrDefault();
                    if (b != null)
                    {
                        b.StartDate = booking.StartDate;
                        b.EndDate = booking.EndDate;
                        b.BookingDays = booking.BookingDays;
                        b.TotalCharges = booking.TotalCharges;
                        b.Extras = booking.Extras;
                        entities.SaveChanges();
                        var res = Request.CreateResponse(HttpStatusCode.OK, "booking updated");
                        res.Headers.Location = new Uri(Request.RequestUri + booking.Id.ToString());
                        return res;
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "booking is not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
