using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTicketBooking.Data;
using OnlineTicketBooking.Model;
using OnlineTicketBooking.Repository.IRepository;

namespace OnlineticketBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _databaseContext;
        private readonly IBookingRepository _bookingRepository;
        private object _dbContext;

        public BookingController(ApplicationDbContext dbContext, IBookingRepository bookingRepository)
        {
            _dbContext = dbContext;
            _bookingRepository = bookingRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _bookingRepository.Get();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Create(Booking booking)
        {

            _bookingRepository.Create(booking);
            _bookingRepository.Save();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Booking booking)
        {
            _bookingRepository.Update(booking);
            _bookingRepository.Save();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _bookingRepository.Delete(id);
            _bookingRepository.Save();
            return Ok();
        }

    }
}
