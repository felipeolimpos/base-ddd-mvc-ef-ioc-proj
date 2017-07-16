using AutoMapper;
using POS.Infra.Cross.AutoMapper;

namespace POS.Web.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DataMappingProfile>();
                x.AddProfile<WebMappingProfile>();
            });
        }
    }
}