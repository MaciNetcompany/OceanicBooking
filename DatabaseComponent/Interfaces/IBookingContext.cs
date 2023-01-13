using DatabaseComponent.Entitities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DatabaseComponent.Interfaces
{
    public interface IBookingContext
    {
        DbSet<UserJPA> Users { get; set; }
        DbSet<CitiesJPA> Cities { get; set; }
        DbSet<FlightsJPA> Flights { get; set; }
        DbSet<BookingsJPA> Bookings { get; set; }
        DbSet<TravelSegmentJPA> TravelSegment { get; set; }
        DbSet<RelationsJPA> Relations { get; set; }
        DbSet<Time_SegmentsJPA> Time_Segmets { get; set; }
    }
}