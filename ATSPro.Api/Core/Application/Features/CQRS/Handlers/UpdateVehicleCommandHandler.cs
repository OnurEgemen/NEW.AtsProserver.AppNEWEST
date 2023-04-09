using ATSPro.Api.Core.Application.Features.CQRS.Commands;
using ATSPro.Api.Core.Application.Interfaces;
using ATSPro.Api.Core.Domain;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Handlers
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommandRequest>
    {
        private readonly IGenericRepository<Vehicle> repository;

        public UpdateVehicleCommandHandler(IGenericRepository<Vehicle> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateVehicleCommandRequest request, 
            CancellationToken cancellationToken)
        {
            var updateVehicle = await this.repository.GetByIdAsync(request.VehicleId);
            if(updateVehicle != null)
            {
                updateVehicle.CategoryId = request.CategoryId;
                updateVehicle.VehicleMake = request.VehicleMake;
                updateVehicle.VehicleBrand = request.VehicleBrand;
                updateVehicle.VehicleName = request.VehicleName;
                await this.repository.UpdateAsync(updateVehicle);
                
            }
            return Unit.Value;
        }
    }
}
