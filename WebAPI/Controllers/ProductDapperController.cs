using AutoMapper;
using LeverX.WebAPI.Features.Products.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.WebAPI.Features.Products.Commands;
using MusicStore.WebAPI.Features.Products.Queries;

namespace LeverX.WebAPI.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/product/dapper")] // Route for api/product
public class ProductDapperController : ControllerBase //Base class
{
    private readonly IMediator _mediator; // Injecting MediatR for CQRS
    private readonly IMapper _mapper; // Injecting AutoMapper
    public ProductDapperController( IMediator mediator, IMapper mapper) 
    {
        _mediator = mediator;
        _mapper = mapper;
    }


   

    /// <summary>
    /// Returns JSON list of Products using Dapper
    /// </summary>
    /// <returns>200 OK</returns>
    [HttpGet] 
    public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllAsyncByDapper() 
    {
        var product = await _mediator.Send(new GetAllProductsQuery());
        return Ok(product);
    }

    /// <summary>
    /// Returns a product of provided ID using Dapper
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <returns>200 OK or 404 NOT FOUND</returns>
    [HttpGet("{id}")] // GET api/product/{id}
    public async Task<ActionResult<ProductReadDto>> GetByIdByDapper([FromRoute] int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        if (product == null)
            return NotFound();

        var productDto = _mapper.Map<ProductReadDto>(product);
        return Ok(productDto);
    }

    /// <summary>
    /// Creates new product using Dapper
    /// </summary>
    /// <param name="productDto">Product Model</param>
    /// <returns>200 OK</returns>
    [HttpPost]
    public async Task<IActionResult> CreateByDapper([FromBody] ProductDto productDto)
    {
        await _mediator.Send(new CreateProductCommand(productDto.Name, productDto.Category, productDto.Price, productDto.ReleaseDate));
        return Ok();
    }

    /// <summary>
    /// Updating a product according to its Id using Dapper
    /// </summary>
    /// <param name="id">Product Id</param>
    /// <param name="productDto">Product Model</param>
    /// <returns>200 OK or 404 NOT FOUND</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateByDapper([FromRoute] int id, [FromBody] ProductDto productDto)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        if (product == null)
            return NotFound();
        else
        {
            await _mediator.Send(new UpdateProductCommand(id, productDto.Name, productDto.Category, productDto.Price, productDto.ReleaseDate));
            return NoContent();
        }
    }

    /// <summary>
    /// Delete product by its Id using Dapper
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <returns>200 OK or 404 NOT FOUND</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteByDapper([FromRoute] int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        if (product == null)
            return NotFound();
        else
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }
    }
}
