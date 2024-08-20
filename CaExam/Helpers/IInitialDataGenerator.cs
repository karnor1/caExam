using CaExam.Models;
using CaExam.Shared;

namespace CaExam.Helpers
{
    public interface IInitialDataGenerator
    {
        UserModel GenerateUserModel(string username, string password, eUserRole role, Guid id);
         UserDetails GenerateUserDetails(Guid userId);
        Address GenerateAddress(Guid userId);

    }
}