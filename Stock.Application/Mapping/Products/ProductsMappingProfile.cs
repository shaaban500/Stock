using AutoMapper;
using Stock.Domain.Entities.Products;
using Stock.Domain.ViewModels.Products;

namespace Stock.Application.Mapping.Products
{
    public class ProductsMappingProfile : Profile
    {
        public ProductsMappingProfile() 
        {
            CreateMap<ProductViewModel, Product>().ReverseMap();
        }
    }
}
