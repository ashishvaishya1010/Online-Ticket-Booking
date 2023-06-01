using System.ComponentModel.DataAnnotations;

namespace OnlineTicketBookingWeb.Models
{
    public class Bookings
    {
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Number of tickets must be at least 1.")]
        public int NumberOfTickets { get; set; }

        public EventsVM Event { get; set; }
    }
}
   