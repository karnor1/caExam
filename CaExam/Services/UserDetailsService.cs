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

        public UserDetailsService(IUserDetailsRepository repository, IWebHostEnvironment enviroment, IImageService imageservice)
        {
            _repository = repository;
            _enviroment = enviroment;
            _imageService = imageservice;
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


    }
}
