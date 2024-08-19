namespace CaExam.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string City {  get; set; }
        public string street { get; set; }
        public string HouseNumber {  get; set; }
        public string? ApartamentNumber { get; set; }

        public Guid UserId { get; set; }
        public UserModel User { get; set; }
    }
}
