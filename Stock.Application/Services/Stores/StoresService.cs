using AutoMapper;
using Stock.Domain.ViewModels.Stores;
using Stock.Domain.Entities.Stores;
using Stock.Domain.Interfaces.Services.Stores;
using Stock.Domain.Interfaces.UnitOfWork;

namespace Stock.Application.Services.store
{
    public class storeService : IStoresService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public storeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<StoreViewModel> GetById(long id = 0)
        { 
            var store = await _unitOfWork.Stores.GetByIdAsync(id);
            var storeViewModel = _mapper.Map<StoreViewModel>(store);
            return storeViewModel;
        }


        public async Task<GetAllStoresViewModel> GetAll()
        {
            var stores = await _unitOfWork.Stores.GetAllAsync();

            var getAllStoresViewModel = new GetAllStoresViewModel
            {
                Stores = _mapper.Map<List<StoreViewModel>>(stores)
            };

            return getAllStoresViewModel;
        }


        public async Task AddOrEdit(Store model)
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
