using AtsProServer.App.Application.Dtos;
using AtsProServer.App.Application.Features.CQRS.Queries;
using AtsProServer.App.Application.Interfaces;
using AtsProServer.App.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Handlers
{
    public class GetVehicleQueryHandler : IRequestHandler
        <GetVehicleQueryRequest, VehicleListDto>
    {
        private readonly IRepository<Vehicle> repository;
        private readonly IMapper mapper;

        public GetVehicleQueryHandler(IRepository<Vehicle> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<VehicleListDto> Handle(GetVehicleQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetByFilterAsync(x=>x.VehicleId == request.Id);

            return this.mapper.Map<VehicleListDto>(data);
        }
    }
}
