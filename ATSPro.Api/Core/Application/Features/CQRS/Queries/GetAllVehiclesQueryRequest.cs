using ATSPro.Api.Core.Application.Dto;
using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Queries
{
    public class GetAllVehiclesQueryRequest : IRequest<List<VehicleListDto>>
    {
    }
}
