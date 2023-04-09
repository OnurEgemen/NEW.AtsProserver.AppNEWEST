using AtsProServer.App.Application.Dtos;
using AtsProServer.App.Application.Features.CQRS.Queries;
using AtsProServer.App.Application.Interfaces;
using AtsProServer.App.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto?>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoryListDto?> Handle(GetCategoryQueryRequest 
            request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetByFilterAsync(x=>x.Id== request.Id);
            return this.mapper.Map<CategoryListDto>(data);
        }
    }
}
