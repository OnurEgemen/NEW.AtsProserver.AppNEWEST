using AtsProServer.App.Application.Dtos;
using AtsProServer.App.Application.Features.CQRS.Commands;
using AtsProServer.App.Application.Interfaces;
using AtsProServer.App.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest
        ,CreatedCategoryResponseDto?>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedCategoryResponseDto?> Handle(CreateCategoryCommandRequest 
            request, CancellationToken cancellationToken)
        {
            var category = new Category { Definition = request.Definition };
            var result = await this.repository.CreateAsync(category);

            return this.mapper.Map<CreatedCategoryResponseDto>(result);
        }
    }
}
