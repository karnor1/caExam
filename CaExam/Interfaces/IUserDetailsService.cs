using CaExam.Helpers;
using CaExam.Models.Dto;

namespace CaExam.Interfaces
{
    public interface IUserDetailsService
    {
        Task<ApiResponse> AddUserDetails(UserDetailsDto details, Guid userid);
        Task<ApiResponse> AddAddress (AddressDto address, Guid userId);
        Task<ApiResponse> UpdateCity(string city, Guid userId);
        Task<ApiResponse> UpdateAddressPropertyAsync(Guid userId, string propertyName, object value);
        Task<ApiResponse> UpdateDetailsPropertyAsync(Guid userId, string propertyName, object value);
    }
}