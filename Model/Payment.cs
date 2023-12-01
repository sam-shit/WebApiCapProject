using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace EventBooking.Models
{
    public class Payment {

       [Key]

       public long PaymentId { get; set; }

       public double Amount { get; set; }

       public DateTime PaymentDate { get; set; }

       public string? ModeOfPayment { get; set; }

 

       [ForeignKey("Booking")]

       public long? BookingId { get; set; }

       public Booking? Booking { get; set; }

   } 
   
}