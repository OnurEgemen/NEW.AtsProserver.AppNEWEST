using AtsProServer.App.Application.Dtos;
using AtsProServer.App.Application.Enums;
using AtsProServer.App.Application.Features.CQRS.Commands;
using AtsProServer.App.Application.Interfaces;
using AtsProServer.App.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Runtime.CompilerServices;

namespace AtsProServer.App.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest,
        CreatedUserDto?>
    {
        private readonly IRepository<AppUser> userRepository;
        private readonly IMapper mapper;

        public RegisterUserCommandHandler(IRepository<AppUser> 
            userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<CreatedUserDto?> Handle(RegisterUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            var data = await this.userRepository.CreateAsync(new AppUser
            {
                AppRoleId = (int)RoleType.Member,
                UserName= request.UserName,
                Password= request.Password,
            });
            return this.mapper.Map<CreatedUserDto>(data);
        }
    }
}
