using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTicketBooking.Data;
using OnlineTicketBooking.DataAccess.Model;
using OnlineTicketBooking.Model;
using OnlineTicketBooking.Model.DTO;
using OnlineTicketBooking.Repository.IRepository;
using System.Data;

namespace OnlineticketBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        protected APIResponse _response;

        public UserController(ApplicationDbContext databaseContext, IUserRepository userRepository)
        {
            _dbContext = databaseContext;
            _userRepository = userRepository;
            this._response = new APIResponse();
        }


        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _userRepository.Login(model);
            if (loginResponse.User == null)
            {

                return BadRequest("Username or password is incorrect");
            }

            return Ok(loginResponse);
        }


        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] User model)
        {
            bool ifCustomerNameUnique = _userRepository.IsUniqueUser(model.UserEmail);
            if (!ifCustomerNameUnique)
            {
                return BadRequest("Username already exists");
            }


            if (model == null)
            {

                return BadRequest("Error while registering");
            }

            //var customer = await _userRepository.Register(model);
            _userRepository.Create(model);

            return Ok();
        }




        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Get()
        {
            var result = _userRepository.Get();
            return Ok(result);
        }
        
        [HttpPut]
       [Authorize(Roles = "admin")]

        public IActionResult Update(User user)
        {
            _userRepository.Update(user);
            _userRepository.Save();
            return Ok(_userRepository.Get());
        }
        [HttpDelete]
       [Authorize(Roles = "admin")]

        public IActionResult Delete(string UserEmail)
        {
            _userRepository.Delete(UserEmail);
            _userRepository.Save();
            return Ok(_userRepository.Get());
        }

        [HttpGet("GetByemail")]
        public IActionResult GetByEmail(string UserEmail)
        {
            var data = _dbContext.Users.Find(UserEmail);
            _response.Result = data;
            return Ok(_response);

        }
    }
}

