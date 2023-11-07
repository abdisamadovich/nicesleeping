using Nicesleeping.DataAccess.Utils;

namespace Nicesleeping.Services.Interfaces.Common;

public interface IPaginator
{
    public void Paginate(long itemsCount, PaginationParams @params);
}
