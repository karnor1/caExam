using CaExam.Models;

namespace CaExam.Interfaces.RepositoryInterfaces
{
    // TODO consider removing inheritence and move needed methods to userrepository
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        Task<UserModel> GetUserByUsernameAsync(string username);
    }
}