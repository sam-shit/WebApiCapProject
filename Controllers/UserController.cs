using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using EventBooking.Models;

namespace EventBooking.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpPost]
        [Route("/api/AddUser")]
        public IActionResult AddUser(User u)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    context.Users.Add(u);
                    context.SaveChanges();

                    return Created("Record Added", u);
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


    }
}