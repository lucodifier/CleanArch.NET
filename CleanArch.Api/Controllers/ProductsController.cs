using Microsoft.AspNetCore.Mvc;
using MediatR;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Contracts;
using CleanArch.Domain.Entities;

namespace CleanArch.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IProductRepository _productRepository;

    public ProductsController(IMediator mediator, IProductRepository productRepository)
    {
        _mediator = mediator;
        _productRepository = productRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateProductCommand command)
    {
        try
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = productId }, productId);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _productRepository.GetAllAsync();
        return Ok(products);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateProductCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID na URL deve corresponder ao ID no comando");

        try
        {
            var success = await _mediator.Send(command);
            if (!success)
                return NotFound();

            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteProductCommand(id);
        var success = await _mediator.Send(command);
        
        if (!success)
            return NotFound();

        return NoContent();
    }
}
