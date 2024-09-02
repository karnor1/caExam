using System.Diagnostics.Tracing;

namespace CaExam.Models.Dto
{
    public class TakeAwayData : UserDetailsDto
    {
        public byte[] PicturePath { get; set; }
        public string City { get; set; }
        public string street { get; set; }
        public string HouseNumber { get; set; }
        public string? ApartamentNumber { get; set; }

        public TakeAwayData(byte[] imageInBytes, Address address, UserDetails userdetails)
        {
            PicturePath = new byte[imageInBytes.Length];
            Array.Copy(imageInBytes, PicturePath, imageInBytes.Length);

            if (imageInBytes == null)
            {
                imageInBytes = new byte[0];
            } else
            {
                PicturePath = imageInBytes;
            }

                street = address?.street;
            ApartamentNumber = address?.ApartamentNumber;
            HouseNumber = address?.HouseNumber;
           City = address?.City;

            Name = userdetails?.Name;
            Surname = userdetails?.Surname;
            Email = userdetails?.Email;
            PersonalIdNumber = userdetails?.PersonalIdNumber;
            PhoneNumber = userdetails?.PhoneNumber;

    }


    }
}
