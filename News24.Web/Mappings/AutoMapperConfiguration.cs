using AutoMapper;
using AutoMapper.Configuration;

namespace News24.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {

            var config = new MapperConfigurationExpression();
            config.AddProfile<AdminToViewModel>();
            config.AddProfile<AdminFromViewModel>();
            config.AddProfile<ToViewModel>();
            config.AddProfile<FromViewModel>();
            Mapper.Initialize(config);
        }
    }
}