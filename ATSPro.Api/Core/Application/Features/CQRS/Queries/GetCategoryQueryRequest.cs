using ATSPro.Api.Core.Application.Dto;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest : IRequest<CategoryListDto?>
    {
        public int Id { get; set; }
        public GetCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
