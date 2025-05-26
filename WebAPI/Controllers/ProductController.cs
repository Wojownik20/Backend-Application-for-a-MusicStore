using LeverX.Application.Interfaces;
using LeverX.Application.Services;
using LeverX.Domain.Models;
using LeverX.WebAPI.ModelsD;
using Microsoft.AspNetCore.Mvc;

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

    /// <summary>
    /// Returns a list of Products
    /// </summary>
    /// <returns>200 and JSON list of products</returns>
    [HttpGet] // GET /api/product
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllAsync() // WebAPI changed for Db
    {
        var product = await _productService.GetAllProductsAsync();
        return Ok(product); // return 200 OK 
    }

    /// <summary>
    /// Returns a product of provided ID
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <returns>Product or Error 404</returns>
    [HttpGet("{id}")] // GET api/product/{id}
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();
        else
        {
            return Ok(product); //200 Ok
        }
    }

    /// <summary>
    /// Creates new product
    /// </summary>
    /// <param name="newProduct">New Product</param>
    /// <returns>201 + Link to get api/product</returns>
    [HttpPost]
    public async Task<IActionResult> Create(ProductDto productDto)
    {
        await _productService.CreateProductAsync(productDto);
        return Ok();
    }

    /// <summary>
    /// Updating a product according to its Id
    /// </summary>
    /// <param name="id">Id of product</param>
    /// <param name="updatedProduct">Updated product</param>
    /// <returns>204 if product updated, 404 if id not found</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(ProductDto productDto)
    {

        await _productService.UpdateProductAsync(productDto);
        return Ok();

    }

    /// <summary>
    /// Delete product by its Id
    /// </summary>
    /// <param name="id">Id of product</param>
    /// <returns>204 if product deleted, 404 if id not found</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.DeleteProductAsync(id);
        return Ok();
    }
}
