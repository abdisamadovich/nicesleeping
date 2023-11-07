namespace Nicesleeping.Domain.Entities.Products_images;

public class ProductImage : Auditable
{
    public long ProductId { get; set; }
    public string ImagePath { get; set; } = string.Empty;
}
