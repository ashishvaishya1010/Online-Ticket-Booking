using OnlineTicketBookingWeb.Models;

namespace OnlineTicketBookingWeb.Services.IServices
{
    public interface IBookingService
    {

        Task<T> GetAllAsync<T>();
        Task<T> GetByid<T>(int id);
        Task<T> CreateAsync<T>(BookingsVM bookings);
        Task<T> UpdateAsync<T>(BookingsVM bookings);
        Task<T> DeleteAsync<T>(int id);
        Task<T> UpdatebyidApprove<T>(int id);
        Task<T> UpdatebyidNotApprove<T>(int id);
        //Task<T> GetByid<T>(int id);

    }
}
