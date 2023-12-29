using AutoMapper;
using Stock.Domain.Entities.Stores;
using Stock.Domain.ViewModels.Stores;

namespace Stock.Application.Mapping.Stores
{
    public class StoresMappingProfile : Profile
    {
        public StoresMappingProfile() 
        {
            CreateMap<StoreViewModel, Store>().ReverseMap();
        }
    }
}
