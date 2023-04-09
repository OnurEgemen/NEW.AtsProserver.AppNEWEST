using ATSPro.Api.Core.Application.Dto;
using ATSPro.Api.Core.Application.Features.CQRS.Queries;
using ATSPro.Api.Core.Application.Interfaces;
using ATSPro.Api.Core.Domain;
using AutoMapper;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryListDto>>
    {
        private readonly IGenericRepository<Category> repository;
        private readonly IMapper mapper;

        public GetCategoriesQueryHandler(IGenericRepository<Category> repository, 
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest request, 
            CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return this.mapper.Map<List<CategoryListDto>>(data);

        }
    }
}
