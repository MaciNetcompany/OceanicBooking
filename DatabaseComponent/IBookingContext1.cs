using Microsoft.EntityFrameworkCore;

namespace DatabaseComponent
{
    public interface IBookingContext1
    {
        DbSet<User> Users { get; set; }
    }
}