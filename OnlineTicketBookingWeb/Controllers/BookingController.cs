using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OnlineTicketBookingWeb.Models;
using OnlineTicketBookingWeb.Services;
using OnlineTicketBookingWeb.Services.IServices;

namespace OnlineTicketBookingWeb.Controllers
{
   // [Authorize]
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
        public IActionResult CreatePage(int eventid)
        {
            TempData["Eventid"] = eventid;
            return View();
        }
        
        public async Task<IActionResult> createenewrecord(BookingsVM bookings)
        {
            bookings.Id = 0;
            bookings.EventId = Convert.ToInt32(TempData["Eventid"]);
            bookings.ApprovedStatus = "Pending";
            bookings.UserEmail = User.Identity.Name;
            await _bookingService.CreateAsync<APIResponse>(bookings);
            TempData["success"] = "Booking Created Successfully ";
            return RedirectToAction("Index");
        }
        //{
        //    bookings.ApprovedStatus = "Notapproved";
        //    await _bookingService.CreateAsync<APIResponse>(bookings);
        //    return RedirectToAction("Index");
        //}
        public async Task<ActionResult> UpdatebyidNotApprove(int id)
        {
            await _bookingService.UpdatebyidNotApprove<APIResponse>(id);
            TempData["success"] = "Rejected ";
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> UpdatebyidApprove(int id)
        {
            await _bookingService.UpdatebyidApprove<APIResponse>(id);
            TempData["success"] = "Approved ";
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Delete(int id)
        {
            await _bookingService.DeleteAsync<APIResponse>(id);
            TempData["success"] = "Booking Deleted Successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            ViewData["Bookid"] = id;

            BookingsVM bookingsVM = new BookingsVM();
            UserVM userVM = new();
            EventsVM eventsVM = new EventsVM();

            var detailsofticket = _bookingService.GetByid<APIResponse>(id);
            if (detailsofticket != null)
            {

                bookingsVM = JsonConvert.DeserializeObject<BookingsVM>(Convert.ToString(detailsofticket.Result.Result));
            }
            // var detailsofevent = _eventService.Getyid<APIResponse>(BookingsVM.EventId);
            
            var detailsofevent = _eventService.GetByid<APIResponse>(bookingsVM.EventId);
            if (detailsofevent != null)
            {

                eventsVM = JsonConvert.DeserializeObject<EventsVM>(Convert.ToString(detailsofevent.Result.Result));
            }
            var userdeatils = _userService.GetByid<APIResponse>(bookingsVM.UserEmail);
            //var userdeatils = _userService.GetByid<APIResponse>("ashish@gmail.com");

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

