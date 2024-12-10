using AutoMapper;
using ProductCatalog.Core.ViewModels;

namespace ProductCatalog.Core.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}
