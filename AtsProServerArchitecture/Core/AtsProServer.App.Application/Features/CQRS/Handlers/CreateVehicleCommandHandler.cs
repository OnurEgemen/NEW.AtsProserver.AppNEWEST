using AtsProServer.App.Application.Dtos;
using AtsProServer.App.Application.Features.CQRS.Commands;
using AtsProServer.App.Application.Interfaces;
using AtsProServer.App.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Handlers
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommandRequest,
        CreatedVehicleDto?>
    {
        private readonly IRepository<Vehicle> repository;
        private readonly IMapper mapper;

        public CreateVehicleCommandHandler(IRepository<Vehicle> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedVehicleDto?> Handle(CreateVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.CreateAsync(new Vehicle
            {
                CategoryId= request.CategoryId,
                VehicleName= request.VehicleName,
                VehicleMake = request.VehicleMake,
                VehicleBrand = request.VehicleBrand
            });

            return this.mapper.Map<CreatedVehicleDto>(data);

        }
    }
}
