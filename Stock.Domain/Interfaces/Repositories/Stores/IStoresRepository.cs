using Stock.Domain.Entities.Stores;
using Stock.Domain.Interfaces.Repositories.Shared;

namespace Stock.Domain.Interfaces.Repositories.Stores
{
    public interface IStoresRepository : IGenericRepository<Store>
    {
    }
}
