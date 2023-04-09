using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Commands
{
    public class UpdateVehicleCommandRequest : IRequest
    {
        public int VehicleId { get; set; }
        public string? VehicleName { get; set; }
        public string? VehicleMake { get; set; }
        public string? VehicleBrand { get; set; }
        public int CategoryId { get; set; }
    }
}
