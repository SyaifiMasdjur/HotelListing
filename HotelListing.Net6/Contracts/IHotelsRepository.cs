using HotelListing.Net6.Data;

namespace HotelListing.Net6.Contracts
{
    public interface IHotelsRepository : IGenericRepository<Hotel>
    {
        Task<Hotel> GetDetails(int id);
    }
}
