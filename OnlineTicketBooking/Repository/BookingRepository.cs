using Microsoft.EntityFrameworkCore;
using OnlineTicketBooking.Data;
using OnlineTicketBooking.Model;
using OnlineTicketBooking.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketBooking.Repository
{
    public  class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
        }

        public void Delete(int Id)
        {
            Booking booking = _dbContext.Bookings.Find(Id);
            _dbContext.Bookings.Remove(booking);
        }

        public IEnumerable<Booking> Get()
        {
            return _dbContext.Bookings.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Booking Booking)
        {
            _dbContext.Entry(Booking).State = EntityState.Modified;
        }
    }
}
    

