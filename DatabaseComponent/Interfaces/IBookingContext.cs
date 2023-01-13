using DatabaseComponent.Entitities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DatabaseComponent.Interfaces
{
    public interface IBookingContext
    {
        DbSet<UserJPA> Users { get; set; }
    }
}