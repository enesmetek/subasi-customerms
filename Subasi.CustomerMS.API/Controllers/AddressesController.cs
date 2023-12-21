using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries;

namespace Subasi.CustomerMS.API.Controllers
{
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IValidator<CreateAddressCommandRequest> _createAddressCommandRequestValidator;
        private readonly IValidator<UpdateAddressCommandRequest> _updateAddressCommandRequestValidator;
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator, 
            IValidator<CreateAddressCommandRequest> createAddressCommandRequestValidator, 
            IValidator<UpdateAddressCommandRequest> updateAddressCommandRequestValidator)
        {
            _mediator = mediator;
            _createAddressCommandRequestValidator = createAddressCommandRequestValidator;
            _updateAddressCommandRequestValidator = updateAddressCommandRequestValidator;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllAddressesQueryRequest());
            return Ok(result);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetAddressQueryRequest(id));
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet]
        [Route("api/Customers/{id}/[controller]")]
        public async Task<IActionResult> GetByCustomerID(int id)
        {
            var result = await _mediator.Send(new GetAllAddressesByCustomerIDQueryRequest(id));
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Create(CreateAddressCommandRequest request)
        {
            var result = _createAddressCommandRequestValidator.Validate(request);
            if(result.IsValid)
            {
                await _mediator.Send(request);
                return Created("Address created successfully.", request);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Update(UpdateAddressCommandRequest request, int id)
        {
            if (id != request.ID) return BadRequest("Route ID and Body ID are not matching.");
            var result = _updateAddressCommandRequestValidator.Validate(request);
            if(result.IsValid)
            {
                await _mediator.Send(request);
                return NoContent();
            }
            return BadRequest(result.Errors); 
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteAddressCommandRequest(id));
            if(result == Unit.Value)
            {
                return BadRequest("Customer not found.");
            }
            return NoContent();
        }
    }
}
