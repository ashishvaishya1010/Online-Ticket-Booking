using OnlineTicketBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketBooking.Repository.IRepository
{
    public interface IBookingRepository
    {
        public IEnumerable<Booking> Get();
        public void Create (Booking booking);
        public void Update (Booking booking);
        public void Delete (int  Id);
        public void Save();

    }
}
