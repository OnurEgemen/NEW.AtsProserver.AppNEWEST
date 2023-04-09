using ATSPro.Api.Core.Application.Enums;
using ATSPro.Api.Core.Application.Features.CQRS.Commands;
using ATSPro.Api.Core.Application.Interfaces;
using ATSPro.Api.Core.Domain;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {

        private readonly IGenericRepository<AppUser> repository;

        public RegisterUserCommandHandler(IGenericRepository<AppUser> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new AppUser
            {
                Password = request.Password,
                UserName = request.UserName,
                AppRoleId = (int)RoleType.Member,
            });

            return Unit.Value;
        }
    }
}
