using Dapper;
using Nicesleeping.DataAccess.Handlers;
using Npgsql;

namespace Nicesleeping.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;
    public BaseRepository()
    {
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new NpgsqlConnection("Host=agileshop-database-host; Port=5432; Database=nicesleeping-db; " +
            "User Id=postgres; Password=0693;");
    }
}
