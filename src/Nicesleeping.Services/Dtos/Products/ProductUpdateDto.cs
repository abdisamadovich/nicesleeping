namespace Nicesleeping.Services.Dtos.Products;

public class ProductUpdateDto
{
    public long CategoryId { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
}
