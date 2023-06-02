using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineTicketBookingWeb.Models;
using OnlineTicketBookingWeb.Services;
using OnlineTicketBookingWeb.Services.IServices;

namespace OnlineTicketBookingWeb.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IEventService _eventService;
        private readonly IUserService _userService;

        public BookingController(IBookingService bookingService, IEventService eventService, IUserService userService)
        {
            _bookingService = bookingService;
            _eventService = eventService;
            _userService = userService;
        }
       // int eventid;
        public async Task<IActionResult> Index()
        {
            List<BookingsVM> list = new();

            var response = await _bookingService.GetAllAsync<APIResponse>();

            if (response != null)
            {
                list = JsonConvert.DeserializeObject<List<BookingsVM>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public IActionResult CreatePage()
        {
            return View();
        }
        
        public async Task<IActionResult> createenewrecord(BookingsVM bookings)
        {
            bookings.ApprovedStatus = "Notapproved";
            await _bookingService.CreateAsync<APIResponse>(bookings);
            return RedirectToAction("Index");
        }
      

        public async Task<ActionResult> Delete(int id)
        {
            await _bookingService.DeleteAsync<APIResponse>(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            ViewData["Bookid"] = id;

            BookingsVM bookingsVM = new BookingsVM();
            UserVM userVM = new();
            EventsVM eventsVM = new EventsVM();

            var detailsofticket = _bookingService.GetAsync<APIResponse>(id);
            if (detailsofticket != null)
            {

                bookingsVM = JsonConvert.DeserializeObject<BookingsVM>(Convert.ToString(detailsofticket.Result.Result));
            }
            // var detailsofevent = _eventService.Getyid<APIResponse>(BookingsVM.EventId);
            
            var detailsofevent = _eventService.GetAsync<APIResponse>(bookingsVM.EventId);
            if (detailsofevent != null)
            {

                eventsVM = JsonConvert.DeserializeObject<EventsVM>(Convert.ToString(detailsofevent.Result.Result));
            }
            var userdeatils = _userService.GetByEmail<APIResponse>(bookingsVM.UserEmail);

            if (userdeatils != null)
            {
                userVM = JsonConvert.DeserializeObject<UserVM>(Convert.ToString(userdeatils.Result.Result));
            }
            BookingDetails bookingDetails = new BookingDetails()

            {
                userVM = userVM,
                eventsVM = eventsVM
            };

            bookingDetails.userVM.Password = "";

            return View(bookingDetails);

        }
    }
}

