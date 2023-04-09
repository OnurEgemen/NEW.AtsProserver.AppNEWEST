using AtsProServer.App.Application.Features.CQRS.Commands;
using AtsProServer.App.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AtsProServer.App.API.Controllers
{
    [Authorize(Roles = "Admin,Member")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehiclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetVehiclesQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetVehicleQueryRequest(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult>Create(CreateVehicleCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("",result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateVehicleCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Remove(int id)
        {
            await _mediator.Send(new RemoveVehicleCommandRequest(id));
            return Ok();
        }


    }

}
