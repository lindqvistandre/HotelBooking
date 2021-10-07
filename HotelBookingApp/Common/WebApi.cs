using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Common
{
    public class WebApi
    {
        /// <summary>  
        /// Get  
        /// </summary>  
        /// <param name="url"></param>  
        /// <returns></returns>  
        public static Task<HttpResponseMessage> GetCall(string url)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = API_URIs.baseURI + url;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync(apiUrl);
                    response.Wait();
                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>  
        /// creates a new employee  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="url"></param>  
        /// <param name="model"></param>  
        /// <returns></returns>  
        public static Task<HttpResponseMessage> PostCall<T>(string url, T model) where T : class
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = API_URIs.baseURI + url;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsJsonAsync(apiUrl, model);
                    response.Wait();
                    return response;
                }
            }
            catch (Exception )
            {
                throw;
            }
        }

        /// <summary>  
        /// Updates  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="url"></param>  
        /// <param name="model"></param>  
        /// <returns></returns>  
        public static Task<HttpResponseMessage> PutCall<T>(string url, T model) where T : class
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = API_URIs.baseURI + url;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PutAsJsonAsync(apiUrl, model);
                    response.Wait();
                    return response;
                }
            }
            catch (Exception )
            {
                throw;
            }
        }

        /// <summary>  
        /// Delete record  
        /// </summary>  
        /// <param name="url"></param>  
        /// <returns></returns>  
        public static Task<HttpResponseMessage> DeleteCall(string url)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = API_URIs.baseURI + url;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.DeleteAsync(apiUrl);
                    response.Wait();
                    return response;
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
