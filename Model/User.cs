using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace EventBooking.Models
{
      public class User {

       [Key]
       public long UserId { get; set; }

       public string UserName { get; set; }

       public string Email { get; set; }

       public string Password { get; set; }

       public long MobileNumber { get; set; }

       public string? UserRole { get; set; }

   }
   
}