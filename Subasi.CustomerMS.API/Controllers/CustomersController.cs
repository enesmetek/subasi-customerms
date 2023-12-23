using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries.Requests;

namespace Subasi.CustomerMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IValidator<CreateCustomerCommandRequest> _createCustomerCommandRequestValidator;
        private readonly IValidator<UpdateCustomerCommandRequest> _updateCustomerCommandRequestValidator;
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator,
            IValidator<CreateCustomerCommandRequest> createCustomerCommandRequestValidator,
            IValidator<UpdateCustomerCommandRequest> updateCustomerCommandRequestValidator)
        {
            _mediator = mediator;
            _createCustomerCommandRequestValidator = createCustomerCommandRequestValidator;
            _updateCustomerCommandRequestValidator = updateCustomerCommandRequestValidator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllCustomersQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetCustomerQueryRequest(id));
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommandRequest request)
        {
            var result = _createCustomerCommandRequestValidator.Validate(request);
            if (result.IsValid)
            {
                await _mediator.Send(request);
                return Created("", request);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateCustomerCommandRequest request, int id)
        {
            if (id != request.ID)
            {
                return BadRequest("Route ID and Body ID are not matching.");
            }
            var validatorResult = _updateCustomerCommandRequestValidator.Validate(request);
            if(validatorResult.IsValid)
            {
                var handlerResult = await _mediator.Send(request);
                if(handlerResult.IsSucceed)
                {
                    return NoContent();
                }
                return NotFound();   
            }
            return BadRequest(validatorResult.Errors);   
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCustomerCommandRequest(id));
            if(result.IsSucceed)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
