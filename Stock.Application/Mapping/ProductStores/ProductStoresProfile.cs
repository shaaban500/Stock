using AutoMapper;
using Stock.Domain.Entities.ProductStores;
using Stock.Domain.ViewModels.Purchase;

namespace Stock.Application.Mapping.ProductStores
{
    public class ProductStoresProfile : Profile
    {
        public ProductStoresProfile()
        {
            CreateMap<GetAllProductStoreViewModel, ProductStore>().ReverseMap();
        }
    }
}
