using ATSPro.Api.Core.Application.Features.CQRS.Commands;
using ATSPro.Api.Core.Application.Interfaces;
using ATSPro.Api.Core.Domain;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IGenericRepository<Category> repository;

        public DeleteCategoryCommandHandler(IGenericRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
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
