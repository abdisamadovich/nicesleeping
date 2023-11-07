using Nicesleeping.DataAccess.Common.Interfaces;
using Nicesleeping.Domain.Entities.Categories;

namespace Nicesleeping.DataAccess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>, IGetAll<Category>
{}
