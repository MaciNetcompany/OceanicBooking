using DatabaseComponent.Entitities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DatabaseComponent.Interfaces
{
    public interface IBookingContext
    {
        public DbSet<UserJPA> Users { get; set; }
        public DbSet<FlightsJPA> Flights { get; set; }
        public DbSet<BookingsJPA> Bookings { get; set; }
        public DbSet<TravelSegmentJPA> TravelSegment { get; set; }
    }
}