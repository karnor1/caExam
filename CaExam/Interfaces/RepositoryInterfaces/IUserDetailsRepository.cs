using CaExam.Models;

namespace CaExam.Interfaces.RepositoryInterfaces
{
    public interface IUserDetailsRepository : IGenericRepository<UserDetails>
    {
        Task<UserDetails> GetByEntityId(Guid ID);
        Task<UserDetails> GetDetailsByUserID(Guid ID);
    }
}
