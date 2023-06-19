using AutoMapper;
using OnlineTicketBooking.Model;
using OnlineTicketBookingWeb.Models;
using System.Runtime.CompilerServices;

namespace OnlineTicketBookingWeb
{
    public class MappingConfig :Profile
    {
        public MappingConfig() 
        {
            CreateMap<Event, EventsVM>().ReverseMap();
            CreateMap<Booking, BookingsVM>().ReverseMap();
        }
    }
}
