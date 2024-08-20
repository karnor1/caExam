using CaExam.Interfaces;
using CaExam.Interfaces.RepositoryInterfaces;
using System.Text;
using CaExam.Models;


namespace CaExam.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;

        public UserAccountService(IPasswordService passwordService, IUserRepository userRepository)
        {
            _passwordService = passwordService;
            _userRepository = userRepository;
        }

        public async Task <bool> RegisterAsync(string username, string password)
        {
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

            return true;


        }
    }
}
