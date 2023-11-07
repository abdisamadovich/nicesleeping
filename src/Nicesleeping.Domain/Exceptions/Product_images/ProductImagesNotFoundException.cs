namespace Nicesleeping.Domain.Exceptions.Product_images;

public class ProductImagesNotFoundException : NotFoundException
{
    public ProductImagesNotFoundException()
    {
        this.TitleMessage = "ProductImages not found!";
    }
}
