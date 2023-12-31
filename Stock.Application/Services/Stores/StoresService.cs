using AutoMapper;
using Stock.Domain.ViewModels.Stores;
using Stock.Domain.Entities.Stores;
using Stock.Domain.Interfaces.Services.Stores;
using Stock.Domain.Interfaces.UnitOfWork;
using NToastNotify;

namespace Stock.Application.Services.store
{
    public class storeService : IStoresService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IToastNotification _toastr;
        public storeService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toastr)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _toastr = toastr;
        }

        public async Task<StoreViewModel> GetById(long id = 0)
        { 
            var store = await _unitOfWork.Stores.GetByIdAsync(id);
            var storeViewModel = _mapper.Map<StoreViewModel>(store);
            return storeViewModel;
        }


        public async Task<List<StoreViewModel>> GetAll()
        {
            var stores = await _unitOfWork.Stores.GetAllAsync();
            var storesViewModel = _mapper.Map<List<StoreViewModel>>(stores);
            return storesViewModel;
        }


        public async Task AddOrEdit(StoreViewModel model)
        {
            var storeToAdd = _mapper.Map<Store>(model);
           
            if (model.Id == 0)
            {
                var store = await _unitOfWork.Stores.AddAsync(storeToAdd);
                _toastr.AddSuccessToastMessage("Added Successfully..");
            }
            else
            {
                var store = await _unitOfWork.Stores.UpdateAsync(storeToAdd);
                _toastr.AddSuccessToastMessage("Updated Successfully..");
            }
        }

        public async Task Delete(long id)
        {
            var store = await _unitOfWork.Stores.GetByIdAsync(x => x.Id == id);

            if (store is not null)
            {
                await _unitOfWork.Stores.DeleteAsync(store);
                _toastr.AddSuccessToastMessage("Deleted Successfully..");
                return;
            }

            _toastr.AddErrorToastMessage("no store found!!");
        }

    }
}
