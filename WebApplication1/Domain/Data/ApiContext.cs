using Microsoft.EntityFrameworkCore;

using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<HotelBooking> Booking { get; set; }

        public ApiContext(DbContextOptions<ApiContext> option)
            :base(option)
        {

        }
    }
}
