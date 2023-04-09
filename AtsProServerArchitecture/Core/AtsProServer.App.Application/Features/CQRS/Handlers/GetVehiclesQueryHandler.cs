using AtsProServer.App.Application.Dtos;
using AtsProServer.App.Application.Features.CQRS.Queries;
using AtsProServer.App.Application.Interfaces;
using AtsProServer.App.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Runtime.CompilerServices;

namespace AtsProServer.App.Application.Features.CQRS.Handlers
{
    public class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQueryRequest,
        List<VehicleListDto>>
    {
        private readonly IRepository<Vehicle> repository;
        private readonly IMapper mapper;

        public GetVehiclesQueryHandler(IRepository<Vehicle> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<VehicleListDto>> Handle(GetVehiclesQueryRequest request, 
            CancellationToken cancellationToken)
        {
            var vehicles = await this.repository.GetAllAsync();

            return this.mapper.Map<List<VehicleListDto>>(vehicles);
        }
    }
}
