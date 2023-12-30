using AutoMapper;
using Stock.Domain.Entities.Stores;
using Stock.Domain.ViewModels.Stores;

namespace Stock.Application.Mapping.Stores
{
    public class ProductsMappingProfile : Profile
    {
        public ProductsMappingProfile() 
        {
            CreateMap<StoreViewModel, Store>().ReverseMap();
        }
    }
}
