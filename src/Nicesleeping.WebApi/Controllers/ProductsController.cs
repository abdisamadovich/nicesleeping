using Microsoft.AspNetCore.Mvc;
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
}
