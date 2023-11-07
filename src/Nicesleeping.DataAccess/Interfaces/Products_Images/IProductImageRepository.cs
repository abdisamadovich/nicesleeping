using Nicesleeping.DataAccess.Common.Interfaces;
using Nicesleeping.Domain.Entities.Products_images;

namespace Nicesleeping.DataAccess.Interfaces.Products_Images;

public interface IProductImageRepository : IRepository<ProductImage, ProductImage>,IGetAll<ProductImage>
{}
