using Stock.Domain.ViewModels.Stores;

namespace Stock.Domain.Interfaces.Services.Stores
{
    public interface IStoresService
    {
        Task<StoreViewModel> GetById(long id = 0);
        Task<List<StoreViewModel>> GetAll();
        Task AddOrEdit(StoreViewModel model);
        Task Delete(long id);
    }
}
