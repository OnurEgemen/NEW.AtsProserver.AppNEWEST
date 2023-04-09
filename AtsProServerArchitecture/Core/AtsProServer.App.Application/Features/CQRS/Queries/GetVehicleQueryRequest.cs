using AtsProServer.App.Application.Dtos;
using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Queries
{
    public class GetVehicleQueryRequest : IRequest<VehicleListDto?>
    {
        public int Id { get; set; }

        public GetVehicleQueryRequest(int id)
        {
            Id = id;
        }
    }
}
