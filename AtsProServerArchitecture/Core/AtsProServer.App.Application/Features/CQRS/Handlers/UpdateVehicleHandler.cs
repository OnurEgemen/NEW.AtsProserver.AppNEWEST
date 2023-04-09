using AtsProServer.App.Application.Features.CQRS.Commands;
using AtsProServer.App.Application.Interfaces;
using AtsProServer.App.Domain.Entities;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Handlers
{
    public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommandRequest>
    {
        private readonly IRepository<Vehicle> repository;

        public UpdateVehicleHandler(IRepository<Vehicle> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateVehicleCommandRequest 
            request, CancellationToken cancellationToken)
        {
            var updatedEntity = await this.repository.GetByIdAsync(request.Id);
            if (updatedEntity != null)
            {
                updatedEntity.VehicleId = request.Id;
                updatedEntity.VehicleName = request.VehicleName; 
                updatedEntity.VehicleMake = request.VehicleMake; 
                updatedEntity.VehicleBrand = request.VehicleBrand;
                updatedEntity.CategoryId = request.CategoryId; 
                
                await this.repository.SaveChangesAsync();

            }

            return Unit.Value;
        }
    }
}
