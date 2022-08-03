using Microsoft.EntityFrameworkCore;

namespace HotelListing.Net6.Data
{
    public class HotelDBContext:DbContext
    {
        public HotelDBContext(DbContextOptions o):base(o)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }


    }
}
