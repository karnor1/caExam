using CaExam.Interfaces.RepositoryInterfaces;
using CaExam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using static CaExam.Repositories.GenericDbRepo;

namespace CaExam.Repositories.SpecificRepositories
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(Context context) : base(context) { }


        // TODO make with predicate of generic repo find.
        public async Task<UserModel> GetUserByUsernameAsync(string username)
        {
            return _dbSet
                    .Where(user => user.Username == username)
                    .FirstOrDefault();
        }

        public async Task<UserModel> GetUserByIdAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<UserModel> GetFullUserByNameAsync(string  name)
        {
            return  _dbSet
                .Include(user => user.UserDetails)
                .Include(user => user.Address) 
                .FirstOrDefault(user => user.Username == name);
        }

        public async Task<UserModel> GetFullUserByIDAsync(Guid Id)
        {
            return _dbSet
                .Include(user => user.UserDetails)
                .Include(user => user.Address)
                .FirstOrDefault(user => user.Id == Id);
        }

    }
}
