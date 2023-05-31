using Microsoft.AspNetCore.Mvc;

namespace OnlineTicketBookingWeb.Areas.Admin.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
