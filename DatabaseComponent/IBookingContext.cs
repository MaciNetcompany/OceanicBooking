using Microsoft.EntityFrameworkCore;

namespace DatabaseComponent
{
    public interface IBookingContext
    {
        DbSet<User> Users { get; set; }
    }
}