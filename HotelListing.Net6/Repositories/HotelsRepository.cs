using HotelListing.Net6.Contracts;
using HotelListing.Net6.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Net6.Repositories
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        public HotelRepository(HotelDBContext context) : base(context)
        {

        }

        public async Task<Hotel> GetDetails(int id)
        {
            return await _context.Hotels.Include(i => i.country).FirstOrDefaultAsync(q=>q.id==id);
        }
    }
}
