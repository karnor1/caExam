using CaExam.Models;

namespace CaExam.Interfaces.RepositoryInterfaces
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<Address> GetByEntityId(Guid ID);
        Task<Address> GetDetailsByUserID(Guid ID);
    }
}
