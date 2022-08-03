using HotelListing.Net6.Data;

namespace HotelListing.Net6.Contracts
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
