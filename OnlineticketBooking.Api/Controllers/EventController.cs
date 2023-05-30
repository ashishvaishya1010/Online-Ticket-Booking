using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTicketBooking.Data;
using OnlineTicketBooking.Model;
using OnlineTicketBooking.Repository.IRepository;

namespace OnlineticketBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext _databaseContext;
        private readonly IEventRepository _eventRepository;

        public EventController(ApplicationDbContext databaseContext, IEventRepository eventRepository)
        {
            _databaseContext = databaseContext;
            _eventRepository = eventRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _eventRepository.Get();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Create(Event Event)
        {

            _eventRepository.Create(Event);
            _eventRepository.Save();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Event Event)
        {
            _eventRepository.Update(Event);
            _eventRepository.Save();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int Eventid)
        {
            _eventRepository.Delete(Eventid);
            _eventRepository.Save();
            return Ok();
        }


    }
}
