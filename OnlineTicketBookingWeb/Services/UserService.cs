using OnlineTicketBookingWeb.Models;
using OnlineTicketBookingWeb.Services.IServices;

namespace OnlineTicketBookingWeb.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IHttpClientFactory _clientFactory;

        private string BookingUrl;
        public UserService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            BookingUrl = configuration.GetValue<string>("ServiceUrls:Event");

        }

        public Task<T> GetByid<T>(string UserEmail)
        {
            return SendAsync<T>(new APIRequest()
            {
                Url = BookingUrl + "/api/User/GetByemail?UserEmail=" + UserEmail,
                ApiType = "GET"

            });
        }

        public Task<T> LoginAsync<T>(LoginRequestVM loginRequestVM)
        {
            throw new NotImplementedException();
        }

        public Task<T> RegisterAsync<T>(UserVM userVM)
        {
            return SendAsync<T>(new APIRequest()
            {
                Url = BookingUrl + "/api/User/register",
                ApiType = "Post",
                Data = userVM


            });
        }
    } 
}

