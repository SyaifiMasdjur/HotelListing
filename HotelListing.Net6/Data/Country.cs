namespace HotelListing.Net6.Data
{
    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortname { get; set; }


        public virtual IList<Hotel> Hotels { get; set; }
    }
}