using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineTicketBookingWeb.Models;
using OnlineTicketBookingWeb.Services.IServices;

namespace OnlineTicketBookingWeb.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public async Task<IActionResult> Index()
        {
            List<Bookings> list = new();

            var response = await _bookingService.GetAllAsync<APIResponse>();

            if (response != null)
            {
                list = JsonConvert.DeserializeObject<List<Bookings>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public IActionResult CreatePage()
        {
            return View();
        }
        public async Task<IActionResult> Create(Bookings bookings)
        {
            await _bookingService.CreateAsync<APIResponse>(bookings);
            return RedirectToAction("Index");
        }
        public IActionResult editpage(int id)
        {

            var response = _bookingService.GetAsync<APIResponse>(id);
            var data = Convert.ToString(response.Result.Result);
            if (response != null)
            {
                EventsVM events = JsonConvert.DeserializeObject<EventsVM>(data);
                return View(events);
            }


            return View();
        }
        public async Task<ActionResult> Edit(Bookings bookings)
        {
            await _bookingService.UpdateAsync<APIResponse>(bookings);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Deleteid(int id)
        {
            await _bookingService.DeleteAsync<APIResponse>(id);
            return RedirectToAction("Index");
        }
    }
}

