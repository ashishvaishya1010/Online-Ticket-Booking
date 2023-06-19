using Microsoft.AspNetCore.Mvc;
using OnlineTicketBookingWeb.Services.IServices;

namespace OnlineTicketBookingWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
