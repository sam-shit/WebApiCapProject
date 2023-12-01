using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Mvc;
using EventBooking.Models;


namespace EventBooking.Models {
    public class ApplicationDbContext : DbContext {
        public virtual DbSet<Booking> Bookings {get; set;} 
        public virtual DbSet<Event> Events {get; set;}
        public virtual DbSet<Payment> Payments {get; set;}
        public virtual DbSet<User> Users {get; set;}
        public virtual DbSet<Status> Statuses {get; set;}
        public virtual DbSet<Organizer> Organizers {get; set;}

        public ApplicationDbContext() {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        } 

    // protected override void OnModelCreating(ModelBuilder modelBuilder) {

    //     modelBuilder.Entity<Booking>()

    //         .HasOne(b => b.Event)

    //         .WithMany()

    //         .HasForeignKey(b => b.EventId);

    //     modelBuilder.Entity<Booking>()

    //         .HasOne(b => b.Payment)

    //         .WithMany()

    //         .HasForeignKey(b => b.PaymentId);

    //     modelBuilder.Entity<Booking>()

    //         .HasOne(b => b.Organizer)

    //         .WithMany()

    //         .HasForeignKey(b => b.OrganizerId);

    //     modelBuilder.Entity<Organizer>()

    //         .HasOne(o => o.User)

    //         .WithMany()

    //         .HasForeignKey(o => o.UserId);

    //     modelBuilder.Entity<Payment>()

    //         .HasOne(p => p.Booking)

    //         .WithMany()

    //         .HasForeignKey(p => p.BookingId);


        



protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if(!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("User ID=sa;password=examlyMssql@123; server=localhost;Database=EventBookingDb;trusted_connection=false;Persist Security Info=False;Encrypt=False");
            }
        }
    }
}
