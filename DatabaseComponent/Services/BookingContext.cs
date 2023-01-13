using DatabaseComponent.Entitities;
using DatabaseComponent.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatabaseComponent.Services;

public class BookingContext : DbContext, IBookingContext
{
    public BookingContext(DbContextOptions<BookingContext> options)
        : base(options)
    {
    }
    public DbSet<UserJPA> Users { get; set; }
    public DbSet<CitiesJPA> Cities { get; set; }
    public DbSet<FlightsJPA> Flights { get; set; }
    public DbSet<BookingsJPA> Bookings { get; set; }
    public DbSet<TravelSegmentJPA> TravelSegment { get; set; }
    public DbSet<RelationsJPA> Relations { get; set; }
    public DbSet<Time_SegmentsJPA> Time_Segmets { get; set; }

}