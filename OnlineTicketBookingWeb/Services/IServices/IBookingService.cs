using OnlineTicketBookingWeb.Models;

namespace OnlineTicketBookingWeb.Services.IServices
{
    public interface IBookingService
    {

        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(Bookings bookings);
        Task<T> UpdateAsync<T>(Bookings bookings);
        Task<T> DeleteAsync<T>(int id);
    }
}
