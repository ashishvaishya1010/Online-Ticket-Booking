using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTicketBooking.Data;
using OnlineTicketBooking.DataAccess.Model;
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
        protected APIResponse _APIResponse;
        public EventController(ApplicationDbContext databaseContext, IEventRepository eventRepository)
        {
            _databaseContext = databaseContext;
            _eventRepository = eventRepository;
            this._APIResponse = new();

        }
        [HttpGet("{id:int}")]
        public IActionResult Getbyid(int id)
        {
            var data = _databaseContext.Events.Find(id);
            _APIResponse.Result = data;
            return Ok(_APIResponse);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _eventRepository.Get();
            _APIResponse.Result = result;
            return Ok(_APIResponse);
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
        [HttpDelete("{Eventid:int}")]
        public IActionResult Delete(int Eventid)
        {
            _eventRepository.Delete(Eventid);
            _eventRepository.Save();
            return Ok();
        }


    }
}
