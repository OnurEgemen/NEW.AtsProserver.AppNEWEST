using AtsProServer.App.Application.Dtos;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest : IRequest<List<CategoryListDto>>
    {
    }
}
