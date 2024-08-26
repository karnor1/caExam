using CaExam.Interfaces.RepositoryInterfaces;
using CaExam.Models;
using Microsoft.EntityFrameworkCore;
using static CaExam.Repositories.GenericDbRepo;


namespace CaExam.Repositories.SpecificRepositories
{

    public class UserDetailsRepository : GenericRepository<UserDetails> , IUserDetailsRepository
    {
        public UserDetailsRepository(Context context) : base(context) { }

        public async Task<UserDetails> GetDetailsByUserID(Guid ID)
        {
            return _dbSet
                    .Where(d => d.UserId == ID)
                    .FirstOrDefault();
        }

        public async Task<UserDetails> GetByEntityId(Guid ID)
        {
            return _dbSet
                    .Where(d => d.Id == ID)
                    .FirstOrDefault();
        }



    }
}