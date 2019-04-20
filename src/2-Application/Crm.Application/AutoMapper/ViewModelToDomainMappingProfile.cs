using AutoMapper;
using Crm.Application.ViewModels;
using Crm.Domain.Models;

namespace Crm.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}