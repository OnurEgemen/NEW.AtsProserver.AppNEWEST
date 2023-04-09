using ATSPro.Api.Core.Application.Dto;
using ATSPro.Api.Core.Application.Features.CQRS.Queries;
using ATSPro.Api.Core.Application.Interfaces;
using ATSPro.Api.Core.Domain;
using AutoMapper;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler :
        IRequestHandler<GetCategoryQueryRequest, CategoryListDto>
    {
        private readonly IGenericRepository<Category> repository;
        private readonly IMapper mapper;

        public GetCategoryQueryHandler(IGenericRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await this
                .repository.GetByFilterAsync(x=>x.Id == request.Id);
            return this.mapper.Map<CategoryListDto>(result);

        }
    }
}
