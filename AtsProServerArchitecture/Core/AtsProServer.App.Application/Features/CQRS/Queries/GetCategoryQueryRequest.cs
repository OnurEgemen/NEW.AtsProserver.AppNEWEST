using AtsProServer.App.Application.Dtos;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Queries
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
