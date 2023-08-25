using AutoMapper;
using MapperStaticApi.Models;

namespace MapperStaticApi
{
    public class MappingProfiles
    {
        public class ProductProfile:Profile
        {
            public ProductProfile()
            {
                CreateMap<Product, ProductDto>();
                CreateMap<Category, CategoryDto>()
                    .ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.Id))
                    .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Name))
                    .ForMember(d => d.CategoryDescription, opt => opt.MapFrom(s => s.Description));
            }
        }
    }
}
