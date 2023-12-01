using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventBooking.Models;

namespace EventBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AdminController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        [Route("ListEvents")]
        public IActionResult GetEvent()
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
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("ListBookings")]
        public IActionResult GetBooking()
        {
            try
            {
                var data = context.Bookings.Include(u => u.Status).ToList();

                if (data.Count > 0)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound("No bookings found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpPost]
        [Route("AddEvent")]
        public IActionResult PostBooking(Event e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Events.Add(e);
                    context.SaveChanges();

                    return Created("Record Added", e);
                }
                else
                {
                    return BadRequest("Invalid model state");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("EditEvent/{id}")]
        public IActionResult PutEvent(long id, Event e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Event ev = context.Events.Find(id);

                    if (ev == null)
                    {
                        return NotFound("Event not found");
                    }

                    ev.EventType = e.EventType;
                    ev.EventDescription = e.EventDescription;
                    ev.ParticipantsCount = e.ParticipantsCount;
                    ev.EventCharges = e.EventCharges;

                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Invalid model state");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DeleteEvent/{id}")]
        public IActionResult DeleteEvent(long id)
        {
            try
            {
                var data = context.Events.Find(id);

                if (data == null)
                {
                    return NotFound();
                }

                context.Events.Remove(data);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ListPayments")]
        public IActionResult GetPayment()
        {
            try
            {
                var data = context.Payments.ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("BookingStatus/Update/{id}/{statusId}")]
        public IActionResult UpdateStatus(long id, int statusId)
        {
            try
            {
                Booking data = context.Bookings.Find(id);

                if (data == null)
                {
                    return NotFound("Booking not found");
                }

                Status selectedStatus = context.Statuses.Find(statusId);
                data.Status = selectedStatus;
                context.SaveChanges();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("/admin/booking/{bookingId}")]
        public IActionResult GetBookingById(long bookingId)
        {
            try
            {
                var data = context.Bookings.Find(bookingId);

                if (data == null)
                {
                    return NotFound("Booking not found");
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("/admin/event/{eventtype}")]
        public IActionResult GetEventByType(string eventtype)
        {
            try
            {
                var data = context.Events.Where(e => e.EventType == eventtype).ToList();

                if (data.Count > 0)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound($"No events found with type: {eventtype}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
