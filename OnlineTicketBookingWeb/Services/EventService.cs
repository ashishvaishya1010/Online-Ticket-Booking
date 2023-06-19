using AutoMapper;
using OnlineTicketBooking.Model;
using OnlineTicketBookingWeb.Models;
using OnlineTicketBookingWeb.Services.IServices;

namespace OnlineTicketBookingWeb.Services
{
    public class EventService : BaseService, IEventService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string eventUrl;
        private readonly IMapper _mapper;

        public EventService(IHttpClientFactory clientFactory, IConfiguration configuration,IMapper mapper) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
            eventUrl = configuration.GetValue<string>("ServiceUrls:Event");

        }

        public Task<T> CreateAsync<T>(EventsVM events)
        {
            var data = _mapper.Map<Event>(events);
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Post",
                Data = data,
                Url = eventUrl + "/api/Event",
              // Token = Token

            });
        }

        public Task<T> DeleteAsync<T>(int Id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Delete",
                Url = eventUrl + "/api/Event/" + Id,
     

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Get",
                Url = eventUrl +"/api/Event",
              

            });
        }

        public Task<T> GetByid<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Get",
                Url = eventUrl + "/api/Event/" + id,
       

            });
        }

        public Task<T> UpdateAsync<T>(EventsVM events)
        {
            var data = _mapper.Map<Event>(events);
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Put",
                Data = data,
                Url = eventUrl + "/api/Event"
             

            });
        }

       
    }
}
    

