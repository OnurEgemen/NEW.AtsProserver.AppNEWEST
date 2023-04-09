using ATSPro.Api.Core.Application.Dto;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest : IRequest<List<CategoryListDto>>
    {
    }
}
