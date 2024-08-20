using CaExam.Shared;

namespace CaExam.Models.Dto
{
    public class UserModelDto
    {
            public string Username { get; set; }
            public byte[] Password { get; set; }
            public byte[] Salt { get; set; }
            public eUserRole Role { get; set; }

    }
}
