using Stock.Domain.Entities.Stores;
using Stock.Domain.ViewModels.Stores;

namespace Stock.Domain.Interfaces.Services.Stores
{
    public interface IStoresService
    {
        Task<StoreViewModel> GetById(long id = 0);
        Task<GetAllStoresViewModel> GetAll();
        Task AddOrEdit(Store model);
        Task Delete(long id);
    }
}
