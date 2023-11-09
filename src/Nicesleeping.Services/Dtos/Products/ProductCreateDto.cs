namespace Nicesleeping.Services.Dtos.Products;

public class ProductCreateDto
{
    public long CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Textile { get; set; } = string.Empty;
    public long Height { get; set; }
    public long LoadPerBerth { get; set; }
    public string Rigidty { get; set; } = string.Empty;
    public long Waranty { get; set; }
}
