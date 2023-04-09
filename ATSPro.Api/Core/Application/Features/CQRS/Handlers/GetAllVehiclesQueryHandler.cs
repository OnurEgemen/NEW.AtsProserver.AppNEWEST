using ATSPro.Api.Core.Application.Dto;
using ATSPro.Api.Core.Application.Features.CQRS.Queries;
using ATSPro.Api.Core.Application.Interfaces;
using ATSPro.Api.Core.Domain;
using AutoMapper;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Handlers
{
    public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQueryRequest
        , List<VehicleListDto>>
    {
        private readonly IGenericRepository<Vehicle> repository;
        private readonly IMapper mapper;

        public GetAllVehiclesQueryHandler(IGenericRepository<Vehicle> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<VehicleListDto>> Handle(GetAllVehiclesQueryRequest 
            request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return this.mapper.Map<List<VehicleListDto>>(data);
        }
    }
}
