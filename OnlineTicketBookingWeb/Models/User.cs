using System.ComponentModel.DataAnnotations;

namespace OnlineTicketBookingWeb.Models
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
