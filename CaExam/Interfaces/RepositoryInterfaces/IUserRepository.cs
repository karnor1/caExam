using CaExam.Models;
using Microsoft.EntityFrameworkCore;

namespace CaExam.Interfaces.RepositoryInterfaces
{
    // TODO consider removing inheritence and move needed methods to userrepository
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        Task<UserModel> GetUserByUsernameAsync(string username);
        Task<UserModel> GetUserByIdAsync(Guid id);

        Task<UserModel> GetFullUserByNameAsync(string name);

        Task<UserModel> GetFullUserByIDAsync(Guid Id);

        



    }
}