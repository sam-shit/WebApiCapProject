using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace EventBooking.Models
{
    public class Status {
    [Key]
    public int StatusId {get; set;}

    public string? StatusType {get; set;}

    }
}
