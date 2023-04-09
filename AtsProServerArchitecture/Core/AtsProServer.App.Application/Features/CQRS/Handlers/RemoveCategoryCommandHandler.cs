using AtsProServer.App.Application.Features.CQRS.Commands;
using AtsProServer.App.Application.Interfaces;
using AtsProServer.App.Domain.Entities;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Handlers
{
    public class RemoveCategoryCommandHandler : 
        IRequestHandler<RemoveCategoryCommandRequest>
    {
        private readonly IRepository<Category> repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RemoveCategoryCommandRequest 
            request, CancellationToken cancellationToken)
        {
            var deletedEntity = await this.repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                await this.repository.Remove(deletedEntity);
            }
            return Unit.Value;
        }
    }
}
