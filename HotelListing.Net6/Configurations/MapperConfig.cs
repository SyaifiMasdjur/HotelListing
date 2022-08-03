using AutoMapper;
using HotelListing.Net6.Data;
using HotelListing.Net6.Models.Country;
using HotelListing.Net6.Models.Hotel;

namespace HotelListing.Net6.Configurations
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CountryDetailDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();

            CreateMap<Hotel, HotelDto>().ReverseMap();


        }
    }
}
