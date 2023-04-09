using ATSPro.Api.Core.Application.Features.CQRS.Commands;
using ATSPro.Api.Core.Application.Interfaces;
using ATSPro.Api.Core.Domain;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Handlers
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommandRequest>
    {
        private readonly IGenericRepository<Vehicle> repository;

        public DeleteVehicleCommandHandler(IGenericRepository<Vehicle> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteVehicleCommandRequest 
            request, CancellationToken cancellationToken)
        {
            var deletedEntity = await this.repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {

            await this.repository.RemoveAsync(deletedEntity);
            }
            return Unit.Value;
        }
    }
}
