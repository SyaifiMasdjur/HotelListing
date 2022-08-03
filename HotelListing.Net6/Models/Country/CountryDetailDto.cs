using HotelListing.Net6.Models.Hotel;

namespace HotelListing.Net6.Models.Country
{
    public class CountryDetailDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortname { get; set; }

        public List<HotelDto> Hotels { get; set; }
    }

}
