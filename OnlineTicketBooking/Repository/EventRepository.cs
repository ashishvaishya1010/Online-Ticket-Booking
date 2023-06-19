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
    public  class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Event Event)
        {
            _dbContext.Events.Add(Event);
        }

        public void Delete(int EventId)

        {
            Event Event = _dbContext.Events.Find(EventId);
            _dbContext.Events.Remove(Event);
        }

        public IEnumerable<Event> Get()
        {
            return _dbContext.Events.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Event Event)
        {

        //    _dbContext.Entry(Events).State = EntityState.Detached;

            _dbContext.Entry(Event).State=EntityState.Modified;
        }
    }
}

