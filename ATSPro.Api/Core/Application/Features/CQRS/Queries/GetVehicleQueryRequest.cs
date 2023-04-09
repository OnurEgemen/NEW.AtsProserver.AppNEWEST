using ATSPro.Api.Core.Application.Dto;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Queries
{
    public class GetVehicleQueryRequest : IRequest<VehicleListDto>
    {
        public int Id { get; set; }

        public GetVehicleQueryRequest(int id)
        {
            Id = id;    
        }
    }
}
