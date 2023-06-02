using OnlineTicketBookingWeb.Models;
using OnlineTicketBookingWeb.Services.IServices;

namespace OnlineTicketBookingWeb.Services
{
    public class UserService : BaseService,IUserService
    {
        private readonly IHttpClientFactory _clientFactory;

        private string TicketBookingUrl;
        public UserService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            TicketBookingUrl = configuration.GetValue<string>("ServiceUrls:BookTicket");

        }

        public Task<T> Getbyid<T>(string CustomerEmail)
        {
            return SendAsync<T>(new APIRequest()
            {
                Url = TicketBookingUrl + "/api/Customer/GetbyEmail/" + CustomerEmail,
                ApiType = "GET",

            });
        }

        public Task<T> LoginAsync<T>(LoginRequestVM loginRequestVM)
        {
            throw new NotImplementedException();
        }

        public Task<T> RegisterAsync<T>(UserVM userVM)
        {
            throw new NotImplementedException();
        }
    }
}

