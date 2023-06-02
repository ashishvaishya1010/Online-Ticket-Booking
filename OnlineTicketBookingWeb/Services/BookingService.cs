using Microsoft.AspNetCore.Mvc;
using OnlineTicketBookingWeb.Models;
using OnlineTicketBookingWeb.Services.IServices;

namespace OnlineTicketBookingWeb.Services
{
    public class BookingService : BaseService, IBookingService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string bookingUrl;

        public BookingService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            bookingUrl = configuration.GetValue<string>("ServiceUrls:Event");

        }

        public Task<T> CreateAsync<T>(BookingsVM bookings)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Post",
                
                Data = bookings,
                Url = bookingUrl + "/api/Booking"
                // Token = Token

            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "delete",
                Url = bookingUrl + "/api/Booking/" + id,


            });
        }

        
        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Get",
                Url = bookingUrl + "/api/Booking"


            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Get",
                Url = bookingUrl + "/api/Booking/"+id,


            });
        }

        public Task<T> UpdateAsync<T>(BookingsVM bookings)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Put",
                Data = bookings,
                Url = bookingUrl + "/api/Booking/" + bookings.Id,


            });
        }
        public Task<T> Updatebyid<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Put",
                Url = bookingUrl + "/api/Booking/Approve/" + id
            }
                );
        }

        public Task<T> UpdatebyidReject<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Put",
                Url = bookingUrl + "/api/Booking/Reject/" + id
            }
                );


        }


    }
}

