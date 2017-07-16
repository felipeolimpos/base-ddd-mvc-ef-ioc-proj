using AutoMapper;
using POS.Domain.Entities;
using POS.Infra.Cross.DTO;

namespace POS.Infra.Cross.AutoMapper
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodDTO>().ReverseMap();
        }
    }
}