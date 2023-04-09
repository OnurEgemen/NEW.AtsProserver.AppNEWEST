using AtsProServer.App.Application.Dtos;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Commands
{
    public class CreateVehicleCommandRequest : IRequest<CreatedVehicleDto?>
    {
        public string? VehicleName { get; set; }
        public string? VehicleMake { get; set; }
        public string? VehicleBrand { get; set; }
        public int CategoryId { get; set; }
    }
}
