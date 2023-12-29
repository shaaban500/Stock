using Stock.Domain.Entities.Stores;

namespace Stock.Domain.Interfaces.Services.Stores
{
    public interface IStoresService
    {
        Task<List<Store>> GetAll();
        Task AddOrUpdate(Store model);
        Task Delete(long id);
    }
}
