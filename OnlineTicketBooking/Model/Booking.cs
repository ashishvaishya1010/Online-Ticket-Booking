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

        public string ApprovedStatus { get; set; }
        public int NumberOfTickets { get; set; }
        
    }
}

