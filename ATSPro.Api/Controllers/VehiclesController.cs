using ATSPro.Api.Core.Application.Features.CQRS.Commands;
using ATSPro.Api.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATSPro.Api.Controllers
{
    [Authorize(Roles="Admin,Member")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : Controller
    {
        private readonly IMediator mediator;

        public VehiclesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await this.mediator
                .Send(new GetAllVehiclesQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new GetVehicleQueryRequest(id));
            return result == null? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var result = await this.mediator.Send(new DeleteVehicleCommandRequest(id));
            return NoContent();

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleCommandRequest request)
        {
            await this.mediator.Send(request);
            return Created("", request);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateVehicleCommandRequest request)
        {
            await this.mediator.Send(request);
            return NoContent();
        }

    }
}

