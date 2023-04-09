using AtsProServer.App.Application.Dtos;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest : IRequest<CreatedCategoryResponseDto?>
    {
        public string? Definition { get; set; }
    }
}
