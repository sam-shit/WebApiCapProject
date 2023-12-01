﻿// <auto-generated />
using System;
using EventBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventBooking.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231130063119_event")]
    partial class @event
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EventBooking.Models.Booking", b =>
                {
                    b.Property<long>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BookingId"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BookingStatus")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<long?>("EventId1")
                        .HasColumnType("bigint");

                    b.Property<int>("Headcount")
                        .HasColumnType("int");

                    b.Property<long>("OrganizerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("OrganizerId1")
                        .HasColumnType("bigint");

                    b.Property<long?>("PaymentId")
                        .HasColumnType("bigint");

                    b.HasKey("BookingId");

                    b.HasIndex("EventId");

                    b.HasIndex("EventId1");

                    b.HasIndex("OrganizerId");

                    b.HasIndex("OrganizerId1");

                    b.HasIndex("PaymentId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("EventBooking.Models.Event", b =>
                {
                    b.Property<long>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EventId"), 1L, 1);

                    b.Property<double>("EventCharges")
                        .HasColumnType("float");

                    b.Property<string>("EventDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParticipantsCount")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventBooking.Models.Organizer", b =>
                {
                    b.Property<long>("OrganizerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrganizerId"), 1L, 1);

                    b.Property<long>("MobileNumber")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("OrganizerId");

                    b.HasIndex("UserId");

                    b.ToTable("Organizers");
                });

            modelBuilder.Entity("EventBooking.Models.Payment", b =>
                {
                    b.Property<long>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PaymentId"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<long>("BookingId")
                        .HasColumnType("bigint");

                    b.Property<string>("ModeOfPayment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentId");

                    b.HasIndex("BookingId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("EventBooking.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"), 1L, 1);

                    b.Property<string>("StatusType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("EventBooking.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MobileNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventOrganizer", b =>
                {
                    b.Property<long>("EventsEventId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrganizersOrganizerId")
                        .HasColumnType("bigint");

                    b.HasKey("EventsEventId", "OrganizersOrganizerId");

                    b.HasIndex("OrganizersOrganizerId");

                    b.ToTable("EventOrganizer");
                });

            modelBuilder.Entity("EventBooking.Models.Booking", b =>
                {
                    b.HasOne("EventBooking.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventBooking.Models.Event", null)
                        .WithMany("Bookings")
                        .HasForeignKey("EventId1");

                    b.HasOne("EventBooking.Models.Organizer", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventBooking.Models.Organizer", null)
                        .WithMany("Bookings")
                        .HasForeignKey("OrganizerId1");

                    b.HasOne("EventBooking.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.Navigation("Event");

                    b.Navigation("Organizer");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("EventBooking.Models.Organizer", b =>
                {
                    b.HasOne("EventBooking.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventBooking.Models.Payment", b =>
                {
                    b.HasOne("EventBooking.Models.Booking", "Booking")
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("EventOrganizer", b =>
                {
                    b.HasOne("EventBooking.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventBooking.Models.Organizer", null)
                        .WithMany()
                        .HasForeignKey("OrganizersOrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventBooking.Models.Event", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("EventBooking.Models.Organizer", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
