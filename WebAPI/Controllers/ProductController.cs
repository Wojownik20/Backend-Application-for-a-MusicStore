﻿using LeverX.WebAPI.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Core.Data;
using MusicStore.Platform.Services.Interfaces;
using MusicStore.Shared.Models;
using WebAPI.ModelsDto;

namespace LeverX.WebAPI.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/[controller]")] // Route for api/product
public class ProductController : ControllerBase //Base class
{
    private readonly IProductService _productService; // Injecting our DB
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    //EF Core

    /// <summary>
    /// Returns a list of Products
    /// </summary>
    /// <returns>200 and JSON list of products</returns>
    [HttpGet] // GET /api/product
    public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllAsync() // WebAPI changed for Db
    {
        var products = await _productService.GetAllProductsAsync();
        var productDtos = products.Select(p => new ProductReadDto
        {
            Id = p.Id,
            Name = p.Name,
            Category = p.Category,
            Price = p.Price,
            ReleaseDate = p.ReleaseDate
        });
        return Ok(productDtos);
    }

    /// <summary>
    /// Returns a product of provided ID
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <returns>Product or Error 404</returns>
    [HttpGet("{id}")] // GET api/product/{id}
    public async Task<ActionResult<ProductReadDto>> GetById([FromRoute] int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();

        var productDto = new ProductReadDto
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category,
            Price = product.Price,
            ReleaseDate = product.ReleaseDate
        };

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
        var product = new Product
        {
            Name = productDto.Name,
            Category = productDto.Category,
            Price = productDto.Price,
            ReleaseDate = productDto.ReleaseDate
        };

        await _productService.CreateProductAsync(product);
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
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();
        else
        {
            product.Name = productDto.Name;
            product.Category = productDto.Category;
            product.Price = productDto.Price;
            product.ReleaseDate = productDto.ReleaseDate;
        }

        await _productService.UpdateProductAsync(product);
        return Ok();
    }

    /// <summary>
    /// Delete product by its Id
    /// </summary>
    /// <param name="id">Id of product</param>
    /// <returns>204 if product deleted, 404 if id not found</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();
        await _productService.DeleteProductAsync(id);
        return Ok();
    }

    //DAPPER

    /// <summary>
    /// Returns JSON list of Products using Dapper
    /// </summary>
    /// <returns>200 OK</returns>
    [HttpGet("dapper")] 
    public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllAsyncByDapper() 
    {
        var products = await _productService.GetAllProductsAsyncByDapper();
        var productDtos = products.Select(p => new ProductReadDto
        {
            Id = p.Id,
            Name = p.Name,
            Category = p.Category,
            Price = p.Price,
            ReleaseDate = p.ReleaseDate
        });
        return Ok(productDtos);
    }

    /// <summary>
    /// Returns a product of provided ID using Dapper
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <returns>200 OK or 404 NOT FOUND</returns>
    [HttpGet("dapper/{id}")] // GET api/product/{id}
    public async Task<ActionResult<ProductReadDto>> GetByIdByDapper([FromRoute] int id)
    {
        var product = await _productService.GetProductByIdAsyncByDapper(id);
        if (product == null)
            return NotFound();

        var productDto = new ProductReadDto
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category,
            Price = product.Price,
            ReleaseDate = product.ReleaseDate
        };

        return Ok(productDto);
    }

    /// <summary>
    /// Creates new product using Dapper
    /// </summary>
    /// <param name="productDto">Product Model</param>
    /// <returns>200 OK</returns>
    [HttpPost("dapper")]
    public async Task<IActionResult> CreateByDapper([FromBody] ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Category = productDto.Category,
            Price = productDto.Price,
            ReleaseDate = productDto.ReleaseDate
        };

        await _productService.CreateProductAsyncByDapper(product);
        return Ok();
    }

    /// <summary>
    /// Updating a product according to its Id using Dapper
    /// </summary>
    /// <param name="id">Product Id</param>
    /// <param name="productDto">Product Model</param>
    /// <returns>200 OK or 404 NOT FOUND</returns>
    [HttpPut("dapper/{id}")]
    public async Task<IActionResult> UpdateByDapper([FromRoute] int id, [FromBody] ProductDto productDto)
    {
        var product = await _productService.GetProductByIdAsyncByDapper(id);
        if (product == null)
            return NotFound();
        else
        {
            product.Name = productDto.Name;
            product.Category = productDto.Category;
            product.Price = productDto.Price;
            product.ReleaseDate = productDto.ReleaseDate;
        }

        await _productService.UpdateProductAsyncByDapper(product);
        return Ok();
    }

    /// <summary>
    /// Delete product by its Id using Dapper
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <returns>200 OK or 404 NOT FOUND</returns>
    [HttpDelete("dapper/{id}")]
    public async Task<IActionResult> DeleteByDapper([FromRoute] int id)
    {
        var product = await _productService.GetProductByIdAsyncByDapper(id);
        if (product == null)
            return NotFound();
        else
        {
        await _productService.DeleteProductAsyncByDapper(id);
        return Ok();
        }    
    }
}
