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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    id = 1,
                    name = "Bahama",
                    shortname = "BHM"
                },
                new Country
                {
                    id = 2,
                    name = "Caribean",
                    shortname = "CRB"
                },
                new Country
                {
                    id = 3,
                    name = "Greece",
                    shortname = "GRC"
                }
                );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    id = 1,
                    name = "Bahama Hotel International",
                     adress = "Bahama Hotel International Address",
                     rating =1,
                     countryId =1

                },
                new Hotel
                {
                    id = 2,
                    name = "Bahama Hotel Leasure Hotel",
                    adress = "Bahama Hotel Leasure Hotel Address",
                    rating = 5,
                    countryId = 1
                },
                new Hotel
                {
                    id = 3,
                    name = "Greece Hotel Leasure Hotel",
                    adress = "Greece  Hotel Leasure Hotel Address",
                    rating = 4,
                    countryId = 3
                });
        }

    }
}
