﻿using Nicesleeping.DataAccess.Utils;
using Nicesleeping.Domain.Entities.Categories;
using Nicesleeping.Services.Dtos.Categories;

namespace Nicesleeping.Services.Interfaces.Categories;

public interface ICategoryService
{
    public Task<bool> CreateAsync(CategoryCreateDto dto);
    public Task<bool> DeleteAsync(long categoryId);
    public Task<long> CountAsync();
    public Task<IList<Category>> GetAllAsync(PaginationParams @params);
    public Task<Category> GetByIdAsync(long categoryId);
    public Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto);
}
