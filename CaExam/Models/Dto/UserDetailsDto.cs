namespace CaExam.Models.Dto
{


    public class UserDetailsDto
    {


        public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string PersonalIdNumber { get; set; }
            public string PhoneNumber { get; set; }
            public IFormFile PicturePath { get; set; }
        
    }
}
