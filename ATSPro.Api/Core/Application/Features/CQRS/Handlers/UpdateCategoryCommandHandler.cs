using ATSPro.Api.Core.Application.Features.CQRS.Commands;
using ATSPro.Api.Core.Application.Interfaces;
using ATSPro.Api.Core.Domain;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IGenericRepository<Category> repository;

        public UpdateCategoryCommandHandler(IGenericRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, 
            CancellationToken cancellationToken)
        {
            var updatedEntity =await this.repository.GetByIdAsync(request.Id);
            
            if (updatedEntity != null) 
            {
                updatedEntity.Definition = request.Definition;
                await this.repository.UpdateAsync(updatedEntity);
            }
            return Unit.Value;

        }
    }
}
