namespace HotelListing.Net6.Models.Hotel
{
    public class HotelDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public double rating { get; set; }

        public int countryId { get; set; }
    }
}