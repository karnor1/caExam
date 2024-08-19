using CaExam.Models;
using Microsoft.EntityFrameworkCore;
using static CaExam.Repositories.GenericDbRepo;
using CaExam.Interfaces.RepositoryInterfaces;

namespace CaExam.Repositories.SpecificRepositories
{

    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(Context context) : base(context) { }
    }
}
