using HotelListing.Net6.Contracts;
using HotelListing.Net6.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Net6.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(HotelDBContext context) : base(context)
        {

        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(i => i.Hotels).FirstOrDefaultAsync(q=>q.id==id);
        }
    }
}
