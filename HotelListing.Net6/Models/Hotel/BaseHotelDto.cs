using System.ComponentModel.DataAnnotations;

namespace HotelListing.Net6.Models.Hotel
{
    public class BaseHotelDto
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string adress { get; set; }
        public double? rating { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int countryId { get; set; }
    }

}