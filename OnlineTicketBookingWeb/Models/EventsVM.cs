using System.ComponentModel.DataAnnotations;

namespace OnlineTicketBookingWeb.Models
{
    public class EventsVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public string EventDescription { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Available seats must be a positive number.")]
        public int AvailableSeats { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }
    }

    public enum ApprovalStatus
    {
        Pending,
        Approved,
        Rejected
    }
}

