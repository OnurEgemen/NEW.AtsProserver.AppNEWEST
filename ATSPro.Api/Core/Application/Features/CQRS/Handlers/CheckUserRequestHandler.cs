using ATSPro.Api.Core.Application.Dto;
using ATSPro.Api.Core.Application.Features.CQRS.Queries;
using ATSPro.Api.Core.Application.Interfaces;
using ATSPro.Api.Core.Domain;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest,
        CheckUserResponseDto>
    {
        private readonly IGenericRepository<AppUser> userRepository;
        private readonly IGenericRepository<AppRole> roleRepository;

        public CheckUserRequestHandler(IGenericRepository<AppUser> userRepository, 
            IGenericRepository<AppRole> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, 
            CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await this.userRepository.GetByFilterAsync(x=>
            x.UserName == request.UserName && x.Password == request.Password);

            if(user == null)
            {
                dto.Exist = false;
            }
            else
            {
                dto.UserName = user.UserName;
                dto.Id = user.Id;
                dto.Exist = true;

                var role = await this.roleRepository.GetByFilterAsync(x =>
                x.Id == user.AppRoleId);
                dto.Role = role?.Definition;
            }

            return dto;
        }
    }
}
