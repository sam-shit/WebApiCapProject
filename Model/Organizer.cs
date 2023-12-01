using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace EventBooking.Models
{
   public class Organizer {

       [Key]

       public long OrganizerId { get; set; }

       [Required]
       [RegularExpression(@"\d{10}", ErrorMessage = "Mobile number should be of 10 digits")]
       public long MobileNumber { get; set; }

 

       [ForeignKey("User")]

       public long ? UserId { get; set; }

       public User? User { get; set; }

 

       public List<Booking>? Bookings { get; set; } = new List<Booking>();

       public List<Event>? Events { get; set; } = new List<Event>();

   }
}