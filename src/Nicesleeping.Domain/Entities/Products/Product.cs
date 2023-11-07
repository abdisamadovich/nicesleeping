namespace Nicesleeping.Domain.Entities.Products;

public class Product : Auditable
{
    public long CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
