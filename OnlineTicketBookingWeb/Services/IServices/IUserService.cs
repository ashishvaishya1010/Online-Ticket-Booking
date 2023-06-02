using OnlineTicketBookingWeb.Models;

namespace OnlineTicketBookingWeb.Services.IServices
{
    public interface IUserService
    {
        Task<T> LoginAsync<T>(LoginRequestVM loginRequestVM);

        Task<T> RegisterAsync<T>(UserVM userVM);
        Task<T> Getbyid<T>(string Email);

    }
}
