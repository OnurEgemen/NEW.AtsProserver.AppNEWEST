using ATSPro.Api.Core.Application.Features.CQRS.Commands;
using ATSPro.Api.Core.Application.Interfaces;
using ATSPro.Api.Core.Domain;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Handlers
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommandRequest>
    {
        private readonly IGenericRepository<Vehicle> repository;

        public CreateVehicleCommandHandler(IGenericRepository<Vehicle> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateVehicleCommandRequest request, 
            CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new Vehicle
            {
                VehicleName = request.VehicleName,
                VehicleMake = request.VehicleMake,
                VehicleBrand = request.VehicleBrand
            });

            return Unit.Value;
        }
    }
}
