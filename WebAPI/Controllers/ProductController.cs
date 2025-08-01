﻿using AutoMapper;
using LeverX.WebAPI.Features.Products.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Platform.Services.Interfaces;
using MusicStore.WebAPI.Features.Products.Commands;
using MusicStore.WebAPI.Features.Products.Queries;

namespace LeverX.WebAPI.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/product")] // Route for api/product
public class ProductController : ControllerBase //Base class
{
    private readonly IMediator _mediator; // Injecting MediatR for CQRS
    private readonly IMapper _mapper; // Injecting AutoMapper
    public ProductController( IMediator mediator, IMapper mapper) 
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    /// <summary>
    /// Returns a list of Products
    /// </summary>
    /// <returns>200 and JSON list of products</returns>
    [HttpGet] // GET /api/product
    public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllAsync() // WebAPI changed for Db
    {
        var product = await _mediator.Send(new GetAllProductsQuery());
        return Ok(product);
    }

    /// <summary>
    /// Returns a product of provided ID
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <returns>Product or Error 404</returns>
    [HttpGet("{id}")] // GET api/product/{id}
    public async Task<ActionResult<ProductReadDto>> GetById([FromRoute] int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        if (product == null)
            return NotFound();

        var productDto = _mapper.Map<ProductReadDto>(product);
        return Ok(productDto);
    }

    /// <summary>
    /// Creates new product
    /// </summary>
    /// <param name="newProduct">New Product</param>
    /// <returns>201 + Link to get api/product</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDto productDto)
    {
        await _mediator.Send(new CreateProductCommand(productDto.Name, productDto.Category, productDto.Price, productDto.ReleaseDate));
        return Ok();
    }

    /// <summary>
    /// Updating a product according to its Id
    /// </summary>
    /// <param name="id">Id of product</param>
    /// <param name="updatedProduct">Updated product</param>
    /// <returns>204 if product updated, 404 if id not found</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductDto productDto)
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
    /// Delete product by its Id
    /// </summary>
    /// <param name="id">Id of product</param>
    /// <returns>204 if product deleted, 404 if id not found</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
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
