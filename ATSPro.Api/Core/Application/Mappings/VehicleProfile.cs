using ATSPro.Api.Core.Application.Dto;
using ATSPro.Api.Core.Domain;
using AutoMapper;

namespace ATSPro.Api.Core.Application.Mappings
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            this.CreateMap<Vehicle, VehicleListDto>().ReverseMap();
        }
    }
}
