using Microsoft.EntityFrameworkCore;
using OnlineTicketBooking.Model;
using OnlineTicketBooking.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketBooking.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public Task Login(LoginRequestDTO model)
        {
            throw new NotImplementedException();
        }
    }

}
