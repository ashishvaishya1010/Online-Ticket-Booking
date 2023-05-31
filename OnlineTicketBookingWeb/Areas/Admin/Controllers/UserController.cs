using Microsoft.AspNetCore.Mvc;

namespace OnlineTicketBookingWeb.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
