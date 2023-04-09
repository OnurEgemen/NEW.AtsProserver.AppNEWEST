using MediatR;

namespace AtsProServer.App.Application.Features.CQRS.Commands
{
    public class RemoveVehicleCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveVehicleCommandRequest(int id)
        {
            Id = id;
        }
    }
}
