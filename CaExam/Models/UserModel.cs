using CaExam.Shared;

namespace CaExam.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public  eUserRole Role { get; set; }
        public Address? Address { get; set; }
        public UserDetails? UserDetails { get; set; }
    }
}
