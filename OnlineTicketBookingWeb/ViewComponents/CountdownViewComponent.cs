using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineTicketBooking.DataAccess.Model;
using OnlineTicketBooking.Model;
using OnlineTicketBookingWeb.Services.IServices;

namespace OnlineTicketBookingWeb.ViewComponents
{
    public class CountdownViewComponent : ViewComponent
    {
        private readonly IEventService _eventService;

        public CountdownViewComponent(IEventService eventService)
        {
            _eventService = eventService;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var events = await _eventService.GetAllAsync<APIResponse>();


            List<Event> model = JsonConvert.DeserializeObject<List<Event>>(Convert.ToString(events.Result));




            Event firstEvent = model.OrderBy(e => e.EventDate).FirstOrDefault();

            if (firstEvent != null)
            {
                var countdownTime = firstEvent.EventDate - DateTime.UtcNow;
                return View("Default", countdownTime);
            }

            return Content("No events found.");
        }
    }
}

