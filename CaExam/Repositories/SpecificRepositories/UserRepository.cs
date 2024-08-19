using CaExam.Interfaces.RepositoryInterfaces;
using CaExam.Models;
using Microsoft.EntityFrameworkCore;
using static CaExam.Repositories.GenericDbRepo;

namespace CaExam.Repositories.SpecificRepositories
{
    public class UserRepository :  GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(Context context) : base(context) { }
        

        // TODO make with predicate of generic repo find.
        public async Task<UserModel> GetUserByUsernameAsync(string username)
        {
            return await _dbSet.SingleOrDefaultAsync(u => u.Username == username);
        }


    }
}
