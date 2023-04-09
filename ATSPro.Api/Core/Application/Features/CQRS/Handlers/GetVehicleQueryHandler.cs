using ATSPro.Api.Core.Application.Dto;
using ATSPro.Api.Core.Application.Features.CQRS.Queries;
using ATSPro.Api.Core.Application.Interfaces;
using ATSPro.Api.Core.Domain;
using AutoMapper;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Handlers
{
    public class GetVehicleQueryHandler : IRequestHandler<GetVehicleQueryRequest, VehicleListDto>
    {

        private readonly IGenericRepository<Vehicle> repository;
        private readonly IMapper mapper;

        public GetVehicleQueryHandler(IGenericRepository<Vehicle> repository, 
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<VehicleListDto> Handle(GetVehicleQueryRequest request, 
            CancellationToken cancellationToken)
        {
            var data = await this.repository
                .GetByFilterAsync(x => x.VehicleId == request.Id);
            return this.mapper.Map<VehicleListDto>(data);
        }
    }
}
