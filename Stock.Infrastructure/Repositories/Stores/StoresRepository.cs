using Microsoft.EntityFrameworkCore;
using Stock.Domain.Entities.Stores;
using Stock.Domain.Interfaces.Repositories.Stores;
using Stock.Infrastructure.Repositories.Shared;

namespace Stock.Infrastructure.Repositories.Stores
{
    public class StoresRepository : GenericRepository<Store>, IStoresRepository
    {
        public StoresRepository(DbContext context) : base(context)
        {
        }
    }
}
