using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TektonLabs.HxArq.Application.Commands;
using TektonLabs.HxArq.Application.Queries;

namespace TektonLabs.HxArq.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateProductCommand> _createValidator;
        private readonly IValidator<UpdateProductCommand> _updateValidator;

        public ProductsController(IMediator mediator, IValidator<CreateProductCommand> createValidator, IValidator<UpdateProductCommand> updateValidator)
        {
            _mediator = mediator;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var validationResult = await _createValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id = productId }, productId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
        {
            command.ProductId = id;
            var validationResult = await _updateValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var existingProduct = await _mediator.Send(new GetProductByIdQuery { ProductId = id });
            if (existingProduct == null)
            {
                return NotFound();
            }

            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var query = new GetProductByIdQuery { ProductId = id };
            var product = await _mediator.Send(query);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
