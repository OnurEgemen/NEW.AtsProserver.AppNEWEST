using AtsProServer.App.Application.Features.CQRS.Commands;
using AtsProServer.App.Application.Interfaces;
using AtsProServer.App.Domain.Entities;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Handlers
{
    public class RemoveVehicleCommandHandler
        : IRequestHandler<RemoveVehicleCommandRequest>
    {
        private readonly IRepository<Vehicle> repository;

        public RemoveVehicleCommandHandler(IRepository<Vehicle> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle
            (RemoveVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            var removedEntity = await this.repository.GetByIdAsync(request.Id);
            if (removedEntity != null)
            {
                await this.repository.Remove(removedEntity);
            }

            return Unit.Value;
        }
    }
}
