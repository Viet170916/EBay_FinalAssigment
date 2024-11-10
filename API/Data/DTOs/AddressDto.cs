namespace API.Data.DTOs
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
