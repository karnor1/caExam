using CaExam.Helpers;
using CaExam.Interfaces;
using CaExam.Interfaces.RepositoryInterfaces;
using CaExam.Models;
using CaExam.Models.Dto;
using CaExam.Repositories.SpecificRepositories;
namespace CaExam.Services
{

    public class UserDetailsService : IUserDetailsService
    {
        private readonly IUserDetailsRepository _repository;
        private readonly IWebHostEnvironment _enviroment;
        private readonly IImageService _imageService;
        private readonly IAddressRepository _addressRepository;


        public UserDetailsService(IUserDetailsRepository repository, IWebHostEnvironment enviroment, IImageService imageservice, IAddressRepository addressRepository)
        {
            _repository = repository;
            _enviroment = enviroment;
            _imageService = imageservice;
            _addressRepository = addressRepository;
        }

        public async Task<ApiResponse> AddUserDetails(UserDetailsDto details, Guid userid)
        {
            var userDetails = new UserDetails
            {
                Email = details.Email,
                Name = details.Name,
                PersonalIdNumber = details.PersonalIdNumber,
                PhoneNumber = details.PhoneNumber,
                Surname = details.Surname,
                UserId = userid,
                Id = new Guid()
            };

            userDetails.PicturePath = await _imageService.SavePictureAsync(details.PicturePath);
            _repository.AddAsync(userDetails);

            await _repository.SaveChangesAsync();

            return ApiResponse.SuccessResponse();

        }

       public async  Task<ApiResponse> AddAddress(AddressDto address, Guid userId)
        {
            var _address = new Address
            {
                City = address.City,
                street = address.street,
                ApartamentNumber = address?.ApartamentNumber ?? "N/A",
                HouseNumber = address.HouseNumber,
                Id = new Guid(),
                UserId = userId
            };

            await _addressRepository.AddAsync(_address);
           await _addressRepository.SaveChangesAsync();
            return ApiResponse.SuccessResponse();
        }

        public async Task<ApiResponse> UpdateCity(string city, Guid userId)
        {
          var address = await  _addressRepository.GetDetailsByUserID(userId);
            address.City = city;
            await _addressRepository.SaveChangesAsync();
            return ApiResponse.SuccessResponse();
        }

        public async Task<ApiResponse> UpdateAddressPropertyAsync(Guid userId, string propertyName, object value )
        {
            var address = await _addressRepository.GetDetailsByUserID(userId);

            if (address == null)
            {
                return ApiResponse.ErrorResponse("No Entity under this user ");
            }

            var propertyInfo = typeof(Address).GetProperty(propertyName);
            if (propertyInfo == null || !propertyInfo.CanWrite)
            {

                return ApiResponse.ErrorResponse("This field is not updatable or does not exist");

            }

            propertyInfo.SetValue(address, Convert.ChangeType(value, propertyInfo.PropertyType));

            await _addressRepository.SaveChangesAsync();

            return ApiResponse.SuccessResponse();
        }

        public async Task<ApiResponse> UpdateDetailsPropertyAsync(Guid userId, string propertyName, object value)
        {
            var address = await _repository.GetDetailsByUserID(userId);

            if (address == null)
            {
                return ApiResponse.ErrorResponse("No Entity under this user ");
            }

            var propertyInfo = typeof(UserDetails).GetProperty(propertyName);
            if (propertyInfo == null || !propertyInfo.CanWrite)
            {

                return ApiResponse.ErrorResponse("This field is not updatable or does not exist");

            }

            propertyInfo.SetValue(address, Convert.ChangeType(value, propertyInfo.PropertyType));

            await _repository.SaveChangesAsync();

            return ApiResponse.SuccessResponse();
        }

    }
}
