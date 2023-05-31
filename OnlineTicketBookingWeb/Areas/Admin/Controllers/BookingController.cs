using Microsoft.AspNetCore.Mvc;

namespace OnlineTicketBookingWeb.Areas.Admin.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
