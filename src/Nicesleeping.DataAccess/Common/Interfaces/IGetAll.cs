using Nicesleeping.DataAccess.Utils;

namespace Nicesleeping.DataAccess.Common.Interfaces;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
}
