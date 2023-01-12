using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DatabaseComponent;

public class BookingContext : DbContext, IBookingContext
{
    public BookingContext(DbContextOptions<BookingContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }

}
