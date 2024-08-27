using CaExam.Models.Dto;

namespace CaExam.Models
{
    public class Address : AddressDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
    }
    

}
