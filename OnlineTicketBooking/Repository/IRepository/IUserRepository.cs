using OnlineTicketBooking.Model;
using OnlineTicketBooking.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketBooking.Repository.IRepository
{
    public  interface IUserRepository
    {
        public IEnumerable<User> Get();
        //public void Create(User user);
        public Task<User> Create(User user);
        public void Update(User user);
        public void Delete(string UserEmail);
        public void Save();
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        //Task<User> Register(RegistrationRequest registrationRequestDTO);
    }
}
