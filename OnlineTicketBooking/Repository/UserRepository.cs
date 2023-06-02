using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineTicketBooking.Data;
using OnlineTicketBooking.Model;
using OnlineTicketBooking.Model.DTO;
using OnlineTicketBooking.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketBooking.Repository
{
   public  class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private string secretKey;

        public UserRepository(ApplicationDbContext databaseContext, IConfiguration configuration)

        {
            _dbContext = databaseContext;
            //secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            secretKey = configuration.GetValue<string>("AppSettings:Secret");
        }

        //public void Create(Customer customer)
        //{
        //    _databaseContext.Customers.Add(customer);
        //}





        public bool IsUniqueUser(string useremail)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserEmail == useremail);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName.ToLower() == loginRequest.UserName.ToLower()
                && u.Password == loginRequest.Password);

            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };

            }
            else
            {

                //if customer was found generate JWT Token

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.UserEmail.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };



                var token = tokenHandler.CreateToken(tokenDescriptor);
                LoginResponseDTO loginResponse = new LoginResponseDTO()
                {
                    Token = tokenHandler.WriteToken(token),
                    User = user,

                };
                return loginResponse;
            }
        }


        public async Task<User> Register(User registerationRequest)
        {
            _dbContext.Users.Add(registerationRequest);
            await _dbContext.SaveChangesAsync();
            registerationRequest.Password = "";
            return registerationRequest;

        }




        public void Delete(string userEmail)
        {
            User user = _dbContext.Users.Find(userEmail);
            _dbContext.Users.Remove(user);
        }

        public IEnumerable<User> Get()
        {
            return _dbContext.Users.ToList();
        }
        public void Update(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task<User> Create(User User)
        {
            _dbContext.Users.Add(User);
            await _dbContext.SaveChangesAsync();
            //registerationRequest.Password = "";
            return User;
        }

        public User GetByEmail(string UserEmail)
        {
            if (UserEmail != null) {
   
            }
            User user = _dbContext.Users.Find(UserEmail);
            return user;
        }
    }
}

        //public void Create(User applicationUser)
        //{
        //    _dbContext.ApplicationUsers.Add(applicationUser);
        //}

        //public void Delete(string ApplicationUserEmail)
        //{
        //    User applicationUser = _dbContext.ApplicationUsers.Find(ApplicationUserEmail);
        //    _dbContext.ApplicationUsers.Remove(applicationUser);
        //}

        //public IEnumerable<User> Get()
        //{
        //    return _dbContext.ApplicationUsers.ToList();
        //}

        //public void Save()
        //{
        //    _dbContext.SaveChanges();
        //}

        //public void Update(User applicationUsers)
        //{
        //    _dbContext.Entry(applicationUsers).State = EntityState.Modified;
        //}

    

