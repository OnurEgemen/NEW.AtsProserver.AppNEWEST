using AtsProServer.App.Application.Dtos;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Commands
{
    public class RegisterUserCommandRequest : IRequest<CreatedUserDto?>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
