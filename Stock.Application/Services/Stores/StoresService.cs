using Stock.Domain.Entities.Stores;
using Stock.Domain.Interfaces.Services.Stores;
using Stock.Domain.Interfaces.UnitOfWork;

namespace Stock.Application.Services.store
{
    public class storeService : IStoresService
    {
        private readonly IUnitOfWork _unitOfWork;
        public storeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Store>> GetAll()
        {
            var stores = await _unitOfWork.Stores.GetAllAsync();
            return stores.ToList();
        }

        public async Task AddOrUpdate(Store model)
        {
            if (model.Id == 0)
            {
                var store = await _unitOfWork.Stores.AddAsync(model);
            }
            else
            {
                var store = await _unitOfWork.Stores.UpdateAsync(model);
            }
        }

        public async Task Delete(long id)
        {
            var store = await _unitOfWork.Stores.GetByIdAsync(x => x.Id == id);

            if (store is not null)
            {
                await _unitOfWork.Stores.DeleteAsync(store);
            }
        }
    }
}
