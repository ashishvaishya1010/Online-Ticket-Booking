using Microsoft.Identity.Client;
using OnlineTicketBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketBooking.Repository.IRepository
{
    public interface IEventRepository
    {
        public IEnumerable<Event> Get();
        public void Create(Event Event);
        public void Update(Event Event);
        public void Delete(int  Id);
        public void Save();

    }
}
