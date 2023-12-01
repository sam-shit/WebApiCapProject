using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace EventBooking.Models
{
      public class Event {

       [Key]

       public long EventId { get; set; }

 
       [Required(ErrorMessage ="Event Type is required")]
       public string? EventType { get; set; }

       public string? EventDescription { get; set; }

 
       [Required(ErrorMessage ="")]
       public int ParticipantsCount { get; set; }

       public double EventCharges { get; set; }

 

       public List<Booking>? Bookings { get; set; } = new List<Booking>();

       public List<Organizer>? Organizers { get; set; } = new List<Organizer>();

   }
   
}