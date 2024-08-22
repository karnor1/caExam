using CaExam.Interfaces;
using CaExam.Interfaces.RepositoryInterfaces;
using System.Text;
using CaExam.Models;
using CaExam.Helpers;
using CaExam.Shared;


namespace CaExam.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public UserAccountService(IPasswordService passwordService, IUserRepository userRepository, IJwtService jwtService)
        {
            _passwordService = passwordService;
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<ApiResponse> RegisterAsync(string username, string password)
        {
            if (String.IsNullOrWhiteSpace(username))
            {
                return ApiResponse.ErrorResponse($"Username '{username}' Is not according to our standarts (Must not be empty), please try again.");
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                return ApiResponse.ErrorResponse($"Password '{password}' Is not according to our standarts (Must not be empty), please try again.");
            }

            if (await _userRepository.GetUserByUsernameAsync(username) != null)
            {
                return ApiResponse.ErrorResponse($"User with username '{username}' already exists.");
            }


            byte[] salt = _passwordService.GenerateSalt();
            byte[] hashedPassword = _passwordService.GenerateHash(Encoding.UTF8.GetBytes(password), salt);

            var userId = Guid.NewGuid();
            var user = new UserModel
            {
                Id = userId,
                Username = username,
                Password = hashedPassword,
                Salt = salt,
                Role = Shared.eUserRole.User,
                Address = null,
                UserDetails = null
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return  ApiResponse.SuccessResponse();


        }

        public async Task<ApiResponse> Login(string username, string password)
        {
            if (String.IsNullOrWhiteSpace(username))
            {
                return ApiResponse.ErrorResponse($"Username '{username}'try .");
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                return ApiResponse.ErrorResponse($"Password '{password}' Is not according to our standarts (Must not be empty), please try again.");

            }
            var  user = _userRepository.GetUserByUsernameAsync(username);
            if ( user != null)
            {
                byte[] salt = user.Result.Salt;

                byte[] hashedPassword = _passwordService.GenerateHash(Encoding.UTF8.GetBytes(password), salt);

                if (hashedPassword.SequenceEqual(user.Result.Password))
                {
                    return ApiResponse<string>.SuccessResponse(_jwtService.GenerateToken(user.Result.Id, user.Result.Role),"Log in successful, use provided jwt for further authorization");
                }

            }

            return ApiResponse.ErrorResponse($"Username and password combination does not exist in our system");





        }
    }
}
