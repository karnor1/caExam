using CaExam.Helpers;
using CaExam.Shared;

namespace CaExam.Interfaces
{
    public interface IUserAccountService
    {
        Task<ApiResponse> RegisterAsync(string username, string password);
        Task<ApiResponse> Login(string username, string password);
        Task<ApiResponse<eUserRole>> GetUserRole (Guid userId);

    }
}