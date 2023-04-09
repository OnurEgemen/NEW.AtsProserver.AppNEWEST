using ATSPro.Api.Core.Application.Features.CQRS.Commands;
using ATSPro.Api.Core.Application.Interfaces;
using ATSPro.Api.Core.Domain;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
    {
        private readonly IGenericRepository<Category> repository;

        public CreateCategoryCommandHandler(IGenericRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async  Task<Unit> Handle(CreateCategoryCommandRequest 
            request, CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new Category
            {
                Definition = request.Definition,
            });
            return Unit.Value;
        }
    }
}
