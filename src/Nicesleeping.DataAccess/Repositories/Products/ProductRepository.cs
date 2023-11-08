using Dapper;
using Nicesleeping.DataAccess.Interfaces.Products;
using Nicesleeping.DataAccess.Utils;
using Nicesleeping.Domain.Entities.Categories;
using Nicesleeping.Domain.Entities.Products;

namespace Nicesleeping.DataAccess.Repositories.Products;

public class ProductRepository : BaseRepository, IProductRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from products";
            var result = await _connection.QuerySingleAsync<long>(query);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Product entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.products(category_id, name, description, created_at, updated_at) VALUES " +
                "(@CategoryId, @Name, @Description, @CreatedAt, @UpdatedAt);";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM products WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM products order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Product>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Product>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Product?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM products where id=@Id";
            var result = await _connection.QuerySingleAsync<Product>(query, new { Id = id });

            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<(int ItemsCount, IList<Product>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Product entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.products " +
                $"SET category_id=@CategoryId, name=@Name, description=@Description, created_at=@CreatedAt," +
                $" updated_at=@UpdatedAt WHERE id={id};";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
