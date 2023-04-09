using AtsProServer.App.Application.Dtos;
using AtsProServer.App.Domain.Entities;
using AutoMapper;

namespace AtsProServer.App.Application.Mappings
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            this.CreateMap<Vehicle,VehicleListDto>().ReverseMap();
            this.CreateMap<Vehicle,CreatedVehicleDto>().ReverseMap();
        }
    }
}
