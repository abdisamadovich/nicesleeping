using Microsoft.AspNetCore.Mvc;
using Nicesleeping.DataAccess.Utils;
using Nicesleeping.Services.Dtos.Categories;
using Nicesleeping.Services.Dtos.Products;
using Nicesleeping.Services.Interfaces.Categories;
using Nicesleeping.Services.Interfaces.Products;
using Nicesleeping.Services.Validators.Dtos.Categories;
using Nicesleeping.Services.Validators.Dtos.Products;

namespace Nicesleeping.WebApi.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;
    private readonly int maxPageSize = 10;
    public ProductsController(IProductService service)
    {
        this._service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] ProductCreateDto dto)
    {
        var createValidator = new ProductCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetByIdAsync(long productId)
        => Ok(await _service.GetByIdAsync(productId));

    [HttpPut("{productId}")]
    public async Task<IActionResult> UpdateAsync(long productId, [FromForm] ProductUpdateDto dto)
    {
        var updateValidator = new ProductUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(productId,dto));
        else return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteAsync(long productId) => Ok(await _service.DeleteAsync(productId));
}
