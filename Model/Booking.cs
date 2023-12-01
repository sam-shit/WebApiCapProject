using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBooking.Models
{
    public class Booking
    {
        [Key]
        public long BookingId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Booking Date")]
        [ValidateBookingDate]
        public DateTime BookingDate { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [ForeignKey("Status")]
        public int? StatusId { get; set; }
        public Status? Status { get; set; }

        [Required]
        public int Headcount { get; set; }

        public double Amount { get; set; }

        [ForeignKey("Event")]
        public long? EventId { get; set; }
        public Event? Event { get; set; }

        [ForeignKey("Payment")]
        public long? PaymentId { get; set; }
        public Payment? Payment { get; set; }

        [ForeignKey("Organizer")]
        public long? OrganizerId { get; set; }
        public Organizer? Organizer { get; set; }
    }

    public class ValidateBookingDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime bookingDate = (DateTime)value;

            if (bookingDate > DateTime.Now)
            {
                return new ValidationResult("Booking date cannot be in the future.");
            }

            return ValidationResult.Success;
        }
    }
}
