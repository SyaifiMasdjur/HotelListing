using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Net6.Data
{
    public class Hotel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public double rating { get; set; }

        [ForeignKey(nameof(countryId))]
        public int countryId { get; set; }
        public Country country { get; set; }

    }
}
