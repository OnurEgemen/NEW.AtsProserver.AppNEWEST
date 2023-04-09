using AtsProServer.App.Application.Dtos;
using AtsProServer.App.Domain.Entities;
using AutoMapper;

namespace AtsProServer.App.Application.Mappings
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            this.CreateMap<AppUser, CreatedUserDto>().ReverseMap();
        }

    }
}
