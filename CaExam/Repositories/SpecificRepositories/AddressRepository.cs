using CaExam.Models;
using Microsoft.EntityFrameworkCore;
using static CaExam.Repositories.GenericDbRepo;
using CaExam.Interfaces.RepositoryInterfaces;

namespace CaExam.Repositories.SpecificRepositories
{

    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(Context context) : base(context) { }

        public async Task<Address> GetDetailsByUserID(Guid ID)
        {
            return _dbSet
                    .Where(d => d.UserId == ID)
                    .FirstOrDefault();
        }

        public async Task<Address> GetByEntityId(Guid ID)
        {
            return _dbSet
                    .Where(d => d.Id == ID)
                    .FirstOrDefault();
        }
    }
}
