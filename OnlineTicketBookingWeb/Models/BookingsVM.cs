using System.ComponentModel.DataAnnotations;

namespace OnlineTicketBookingWeb.Models
{
    public class BookingsVM
    {
        public int Id { get; set; }
        [Required]
        public int EventId { get; set; }
        public string UserEmail { get; set; }
        
        //public string UserName { get; set; }
        public int NumberOfTickets { get; set; }
        public string ApprovedStatus { get; set; }


    }
}
   