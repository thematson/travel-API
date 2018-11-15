using Microsoft.EntityFrameworkCore;

namespace FlightandHotel.Models
{
    public class FlightAndHotelContext : DbContext
    {
        public FlightAndHotelContext(DbContextOptions<FlightAndHotelContext> options)
            : base(options) { }

        public DbSet<FlightAndHotel> FlightAndHotel { get; set; }
    }
}
