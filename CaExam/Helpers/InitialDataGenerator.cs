using CaExam.Interfaces;
using CaExam.Models;
using CaExam.Shared;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text;
using Bogus;
using Bogus.Extensions.Sweden;

namespace CaExam.Helpers
{
    public class InitialDataGenerator : IInitialDataGenerator
    {

        private  readonly IPasswordService _passwordService;
        Faker _faker= new Faker();


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
                Email = _faker.Person.Email,
                Name = _faker.Person.FirstName,
                PersonalIdNumber = _faker.Person.Personnummer(),
                PhoneNumber = _faker.Phone.PhoneNumber(),
                Surname = _faker.Person.LastName,
                UserId = userId,
                PicturePath = "somewhere in server"
            };
        }

        public Address GenerateAddress(Guid userId)
        {
            return new Address
            {
                Id =  Guid.NewGuid(),
                City = _faker.Address.City(),
                street = _faker.Address.StreetName(),
                ApartamentNumber = _faker.Address.BuildingNumber(),
                HouseNumber = _faker.Address.BuildingNumber(),
                UserId = userId
            };
        }


    }
}
