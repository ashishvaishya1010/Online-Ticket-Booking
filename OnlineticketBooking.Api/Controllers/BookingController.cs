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
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _databaseContext;
        private readonly IBookingRepository _bookingRepository;
        private object _dbContext;
        protected APIResponse _APIResponse;

        public BookingController(ApplicationDbContext databaseContext, IBookingRepository bookingRepository)
        {
            _databaseContext = databaseContext;
            _bookingRepository = bookingRepository;
            this._APIResponse = new APIResponse();
        }

      
        [HttpGet]
        public IActionResult Get()
        {
            var result = _bookingRepository.Get();
            _APIResponse.Result = result;
            return Ok(_APIResponse);
        }

        [HttpGet("{id:int}")]
        public IActionResult Getbyid(int id)
        {
            var data = _databaseContext.Bookings.Find(id);
            _APIResponse.Result = data;
            return Ok(_APIResponse);
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
        [HttpPut("Approve/{id:int}")]
        public IActionResult Updatebyid(int id)
        {
            var data = _databaseContext.Bookings.Find(id);
            data.ApprovedStatus = "Approved";
            _bookingRepository.Update(data);
            _bookingRepository.Save();
            return Ok();


        }

        [HttpPut("Reject/{id:int}")]
        public IActionResult UpdatebyidReject(int id)
        {
            var data = _databaseContext.Bookings.Find(id);
            data.ApprovedStatus = "Rejected";
            _bookingRepository.Update(data);
            _bookingRepository.Save();
            return Ok();


        }



        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            _bookingRepository.Delete(id);
            _bookingRepository.Save();
            return Ok();
        }
    }

}

