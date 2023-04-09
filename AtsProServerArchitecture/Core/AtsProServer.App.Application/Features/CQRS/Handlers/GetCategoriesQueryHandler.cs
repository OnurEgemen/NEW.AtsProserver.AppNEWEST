using AtsProServer.App.Application.Dtos;
using AtsProServer.App.Application.Features.CQRS.Queries;
using AtsProServer.App.Application.Interfaces;
using AtsProServer.App.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Handlers
{
    public class GetCategoriesQueryHandler :
        IRequestHandler<GetCategoriesQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public GetCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest 
            request, CancellationToken cancellationToken)
        {
            var categories = await this.repository.GetAllAsync();

            return this.mapper.Map<List<CategoryListDto>>(categories);
        }
    }
}
