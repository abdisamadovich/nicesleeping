using Nicesleeping.DataAccess.Common.Interfaces;
using Nicesleeping.Domain.Entities.Products;

namespace Nicesleeping.DataAccess.Interfaces.Products;

public interface IProductRepository : IRepository<Product,Product>, IGetAll<Product>,ISearchable<Product>
{}
