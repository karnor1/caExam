namespace CaExam.Models
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PersonalIdNumber { get; set; }
        public string PhoneNumber {  get; set; }
        public string PicturePath { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }

    }
}
