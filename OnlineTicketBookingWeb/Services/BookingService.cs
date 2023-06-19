using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineTicketBooking.Model;
using OnlineTicketBookingWeb.Models;
using OnlineTicketBookingWeb.Services.IServices;

namespace OnlineTicketBookingWeb.Services
{
    public class BookingService : BaseService, IBookingService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string bookingUrl;
        private readonly IMapper _mapper;

        public BookingService(IHttpClientFactory clientFactory, IConfiguration configuration ,IMapper mapper) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
            bookingUrl = configuration.GetValue<string>("ServiceUrls:Event");

        }

        public Task<T> CreateAsync<T>(BookingsVM bookings)
        {
            var data = _mapper.Map<Booking>(bookings);
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Post",
                Data = data,
                Url = bookingUrl + "/api/Booking"
                // Token = Token

            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "delete",
                Url = bookingUrl + "/api/Booking/" + id


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

        public Task<T> GetByid<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Get",
                Url = bookingUrl + "/api/Booking/" + id


            });
        }

        public Task<T> UpdateAsync<T>(BookingsVM bookings)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Put",
                Data = bookings,
                Url = bookingUrl + "/api/Booking/" + bookings.Id


            });
        }

        //Appoved 
        public Task<T> UpdatebyidApprove<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Put",
                // Data = bookings,
                Url = bookingUrl + "/api/Booking/Approve/" + id


            });
        }
        //Rejected 

        public Task<T> UpdatebyidNotApprove<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Put",
                //   Data = bookings,
                Url = bookingUrl + "/api/Booking/Reject/" + id


            });
        }
    }
}

