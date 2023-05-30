using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketBooking.Model
{
    public class User
    {
        [StringLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        public string UserName { get; set; }
        [Key]
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }


}

