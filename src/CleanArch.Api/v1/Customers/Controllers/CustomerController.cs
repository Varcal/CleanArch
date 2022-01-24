using System;
using System.Net.Mime;
using System.Threading.Tasks;
using CleanArch.Application.Customers.Commands;
using CleanArch.Application.Customers.Events;
using CleanArch.Application.Customers.Models;
using CleanArch.Application.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanArch.Api.v1.Customers.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerCreatedEvent), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Create a new customer")]
        [Route("")]
        public async Task<IActionResult> Create([FromBody]CustomerCreateCommand customerCreateCommand)
        {

            var result = await _mediator.Send(customerCreateCommand);
            return Ok(result);
        }


        [HttpGet]
        [ProducesResponseType(typeof(CustomerModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomerModel), StatusCodes.Status204NoContent)]
        [SwaggerOperation(Summary = "Get customer by id")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {

            var result = await _mediator.Send(new CustomerGetByIdQuery(id));

            if (result == null) return NoContent();

            return Ok(result);
        }
    }
}
