using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using REST_API.Models;

namespace REST_API.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(string username, string Password)
        {
            try
            {
                using (HotelBookingEntities entities = new HotelBookingEntities())
                {
                    var _loggedUser = entities.Customers.FirstOrDefault(X => X.Username.ToLower() == username.ToLower() && X.Password == Password);
                    if (_loggedUser != null)
                    {
                        CustomerModel customerModel = new CustomerModel();
                        customerModel.Id = _loggedUser.Id;
                        customerModel.Contact = _loggedUser.Contact;
                        customerModel.Email = _loggedUser.Email;
                        customerModel.FullName = _loggedUser.FullName;
                        customerModel.Gender = _loggedUser.Gender;
                        customerModel.Password = _loggedUser.Password;
                        customerModel.Username = _loggedUser.Username;
                        return Ok(customerModel);
                    }
                    else
                    {
                        return Content(HttpStatusCode.NotFound, "Invalid Credentials");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);

            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Customer customer)
        {
            try
            {
                using (HotelBookingEntities entities = new HotelBookingEntities())
                {
                    entities.Customers.Add(customer);
                    entities.SaveChanges();
                    var res = Request.CreateResponse(HttpStatusCode.Created, customer);
                    res.Headers.Location = new Uri(Request.RequestUri + customer.Id.ToString());
                    return res;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
