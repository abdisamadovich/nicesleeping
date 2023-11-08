using Nicesleeping.DataAccess.Utils;
using Nicesleeping.Domain.Entities.Categories;
using Nicesleeping.Domain.Entities.Products;
using Nicesleeping.Services.Dtos.Categories;
using Nicesleeping.Services.Dtos.Products;

namespace Nicesleeping.Services.Interfaces.Products;

public interface IProductService
{
    public Task<bool> CreateAsync(ProductCreateDto dto);
    public Task<bool> DeleteAsync(long productId);
    public Task<long> CountAsync();
    public Task<IList<Product>> GetAllAsync(PaginationParams @params);
    public Task<Product> GetByIdAsync(long productId);
    public Task<bool> UpdateAsync(long productId, ProductUpdateDto dto);
}