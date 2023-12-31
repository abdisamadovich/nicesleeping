﻿using Nicesleeping.DataAccess.Interfaces.Categories;
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
    private readonly ICategoryRepository _categoryRepository;
    private readonly IPaginator _paginator;

    public ProductService(IProductRepository productRepository, IPaginator paginator, ICategoryRepository categoryRepository)
    {
        this._repository = productRepository;
        this._paginator = paginator;
        this._categoryRepository = categoryRepository;
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
            Textile = dto.Textile,
            Height = dto.Height,
            LoadPerBerth = dto.LoadPerBerth,
            Rigidty = dto.Rigidty,
            Waranty = dto.Waranty,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var notfound = await _categoryRepository.GetByIdAsync(product.CategoryId);
        if (notfound == null) throw new CategoryNotFoundException();

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

    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        var products = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return products;
    }

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
        product.Textile = dto.Textile;
        product.Height = dto.Height;
        product.LoadPerBerth = dto.LoadPerBerth;
        product.Rigidty = dto.Rigidty;
        product.Waranty = dto.Waranty;
        product.UpdatedAt = TimeHelper.GetDateTime();

        var Result = await _repository.UpdateAsync(productId, product);

        return Result > 0;
    }
}
