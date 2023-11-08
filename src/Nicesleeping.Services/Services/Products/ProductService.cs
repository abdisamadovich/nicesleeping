using Nicesleeping.DataAccess.Interfaces.Categories;
using Nicesleeping.DataAccess.Interfaces.Products;
using Nicesleeping.DataAccess.Utils;
using Nicesleeping.Domain.Entities.Categories;
using Nicesleeping.Domain.Entities.Products;
using Nicesleeping.Domain.Exceptions.Categories;
using Nicesleeping.Domain.Exceptions.Products;
using Nicesleeping.Services.Commons.Helpers;
using Nicesleeping.Services.Dtos.Products;
using Nicesleeping.Services.Interfaces.Common;
using Nicesleeping.Services.Interfaces.Products;

namespace Nicesleeping.Services.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    private readonly IPaginator _paginator;

    public ProductService(IProductRepository productRepository, IPaginator paginator)
    {
        this._repository = productRepository;
        this._paginator = paginator;
    }
    public async Task<long> CountAsync()
    {
        return await _repository.CountAsync();
    }

    public async Task<bool> CreateAsync(ProductCreateDto dto)
    {
        Product product = new Product()
        {
            CategoryId = dto.CategoryId,
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(product);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long productId)
    {
        var product = await _repository.GetByIdAsync(productId);
        if (product is null) throw new ProductNotFoundException();

        var Result = await _repository.DeleteAsync(productId);

        return Result > 0;
    }

    //GetAll ga productImage va Characteristics ni ham olib kelishim kerak
    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        var products = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return products;
    }

    //GetById ga productImage va Characteristics ni ham olib kelishim kerak
    public async Task<Product> GetByIdAsync(long productId)
    {
        var product = await _repository.GetByIdAsync(productId);
        if (product is null) throw new ProductNotFoundException();

        return product;
    }

    public async Task<bool> UpdateAsync(long productId, ProductUpdateDto dto)
    {
        var product = await _repository.GetByIdAsync(productId);
        if (product is null) throw new ProductNotFoundException();

        product.CategoryId = dto.CategoryId;
        product.Name = dto.Name;
        product.Description = dto.Description;
        product.UpdatedAt = TimeHelper.GetDateTime();

        var Result = await _repository.UpdateAsync(productId, product);

        return Result > 0;
    }
}
