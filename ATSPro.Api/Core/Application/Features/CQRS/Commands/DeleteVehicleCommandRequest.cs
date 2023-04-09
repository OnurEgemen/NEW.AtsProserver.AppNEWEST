using MediatR;

namespace ATSPro.Api.Core.Application.Features.CQRS.Commands
{
    public class DeleteVehicleCommandRequest : IRequest
    {
        public int Id { get; set; }
        public DeleteVehicleCommandRequest(int id)
        {
            Id = id;
        }
    }
}
