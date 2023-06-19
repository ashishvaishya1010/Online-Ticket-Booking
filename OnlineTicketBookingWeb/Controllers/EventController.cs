using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineTicketBookingWeb.Models;
using OnlineTicketBookingWeb.Services.IServices;

namespace OnlineTicketBookingWeb.Controllers
{
   //  [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        public async Task<IActionResult> Index()
        {
            List<EventsVM> list = new();

            var response = await _eventService.GetAllAsync<APIResponse>();

            if (response != null)
            {
                list = JsonConvert.DeserializeObject<List<EventsVM>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public IActionResult CreatePage()
        {
            return View();
        }
        public async Task<IActionResult> createenewrecord(EventsVM events)
        {
           await _eventService.CreateAsync<APIResponse>(events);
            TempData["success"] = "Event Created Successfully";
            return RedirectToAction("Index");
        }
        public IActionResult editpage(int id)
        {

            var response = _eventService.GetByid<APIResponse>(id);
            var data = Convert.ToString(response.Result.Result);
            if (response != null)
            {
                EventsVM events = JsonConvert.DeserializeObject<EventsVM>(data);
                return View(events);
            }


            return View();
        }
        public async Task<ActionResult> Edit(EventsVM events)
        {
            await _eventService.UpdateAsync<APIResponse>(events);
            TempData["success"] = "Event Updated Successfully";
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Deletebyid(int Id)
        {
            await _eventService.DeleteAsync<APIResponse>(Id);
            TempData["success"] = "Event Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
