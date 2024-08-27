using CaExam.Models.Dto;
using CaExam.Shared;

namespace CaExam.Models
{
    public class UserModel : UserModelDto
    {
        public Guid Id { get; set; }
        public Address? Address { get; set; }
        public UserDetails? UserDetails { get; set; }
    }
}
