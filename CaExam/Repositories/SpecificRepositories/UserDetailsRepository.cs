using CaExam.Interfaces.RepositoryInterfaces;
using CaExam.Models;
using Microsoft.EntityFrameworkCore;
using static CaExam.Repositories.GenericDbRepo;


namespace CaExam.Repositories.SpecificRepositories
{

    public class UserDetailsRepository : GenericRepository<UserDetails> , IUserDetailsRepository
    {
        public UserDetailsRepository(Context context) : base(context) { }
    }
}