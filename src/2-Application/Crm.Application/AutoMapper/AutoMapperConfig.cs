using AutoMapper;

namespace Crm.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        protected static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}