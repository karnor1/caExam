using CaExam.Interfaces;
using CaExam.Models;
using CaExam.Shared;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text;

namespace CaExam.Helpers
{
    public class InitialDataGenerator : IInitialDataGenerator
    {

        private  readonly IPasswordService _passwordService;

        public InitialDataGenerator(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        public UserModel GenerateUserModel(string username, string password, eUserRole role, Guid id)
        {
            byte[] salt = _passwordService.GenerateSalt();
            byte[] hashedPassword = _passwordService.GenerateHash(Encoding.UTF8.GetBytes(password), salt);

            return new UserModel { Id = id, Username = username, Password = hashedPassword, Role = role, Salt = salt, Address = null, UserDetails = null };
        }

        public UserDetails GenerateUserDetails(Guid userId)
        {
            return new UserDetails
            {
                Id =  Guid.NewGuid(),
                Email = "tele2@hotmail.com",
                Name = "zmogus",
                PersonalIdNumber = "37707727776",
                PhoneNumber = "8644785417",
                Surname = "zmogaitis",
                UserId = userId,
                PicturePath = "somewhere in server"
            };
        }

        public Address GenerateAddress(Guid userId)
        {
            return new Address
            {
                Id =  Guid.NewGuid(),
                City = "Vilnius",
                street = "Kauno",
                ApartamentNumber = "1",
                HouseNumber = "2",
                UserId = userId
            };
        }


    }
}
