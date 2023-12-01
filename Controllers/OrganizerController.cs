using Microsoft.AspNetCore.Mvc;
using EventBooking.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventBooking.Controllers
{
    [ApiController]
    public class OrganizerController : ControllerBase {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpPost]
        [Route("/api/[controller]/booking")]
        public IActionResult AddBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingBooking = context.Bookings
                        .FirstOrDefault(b => b.EventId == booking.EventId && b.BookingDate == booking.BookingDate);

                    if (existingBooking != null)
                    {
                        return BadRequest("Booking for the same event and date already exists");
                    }

                    booking.StatusId = 1;

                    var status = context.Statuses.Find(booking.StatusId);
                    if (status == null)
                    {
                        return NotFound("Status not found");
                    }

                    context.Bookings.Add(booking);
                    booking.Status = status;
                    context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
            return Created("Booking Added", booking);
        }


        [HttpGet]
        [Route("/api/event")]
        public IActionResult ViewEvents()
        {
            try
            {
                var data = context.Events.ToList();

                if (data.Count > 0)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound("No events found");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("/api/[controller]/Payments")]
        public IActionResult AddPayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Payments.Add(payment);
                    context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
            return Created("Payment Successful", payment);
        }

        [HttpGet]
        [Route("/api/[controller]/payment")]
        public IActionResult ViewPayment()
        {
            try
            {
                var data = context.Payments.ToList();

                if (data.Count > 0)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound("No payments found");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("/api/[controller]/booking/{id}")]
        public IActionResult ViewBookingById(int id)
        {
            try
            {
                var data = context.Bookings.Where(m => m.BookingId == id).ToList();

                if (data.Count > 0)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound($"No booking found with ID: {id}");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
