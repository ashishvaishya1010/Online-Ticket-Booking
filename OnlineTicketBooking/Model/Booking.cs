using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketBooking.Model
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Number of tickets must be at least 1.")]
        public int NumberOfTickets { get; set; }

        public Event Event { get; set; }
    }
}

