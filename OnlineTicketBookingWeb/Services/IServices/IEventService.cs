using OnlineTicketBooking.Model;
using OnlineTicketBookingWeb.Models;

namespace OnlineTicketBookingWeb.Services.IServices
{
    public interface IEventService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetByid<T>(int id);
        Task<T> CreateAsync<T>(EventsVM events);
        Task<T> UpdateAsync<T>(EventsVM events);
        Task<T> DeleteAsync<T>(int Id);

    }
}
