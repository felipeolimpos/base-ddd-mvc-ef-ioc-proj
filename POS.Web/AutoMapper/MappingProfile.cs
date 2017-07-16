using AutoMapper;
using POS.Infra.Cross.DTO;
using POS.Web.ViewModels;

namespace POS.Web.AutoMapper
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<CategoryDTO, CategoryViewModel>()
                .ReverseMap()
                .ForMember(dto => dto.CreatedAt, opt => opt.Ignore());
            CreateMap<ProductDTO, ProductViewModel>()
                .ReverseMap()
                .ForMember(dto => dto.CreatedAt, opt => opt.Ignore());
            CreateMap<PaymentMethodDTO, PaymentMethodViewModel>()
                .ReverseMap()
                .ForMember(dto => dto.CreatedAt, opt => opt.Ignore());
        }
    }
}