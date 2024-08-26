using CaExam.Helpers;
using CaExam.Models.Dto;

namespace CaExam.Interfaces
{
    public interface IUserDetailsService
    {
        Task<ApiResponse> AddUserDetails(UserDetailsDto details, Guid userid);
        Task<ApiResponse> AddAddress (AddressDto address, Guid userId);
    }
}