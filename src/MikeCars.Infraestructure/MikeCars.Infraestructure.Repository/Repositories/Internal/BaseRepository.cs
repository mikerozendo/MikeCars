namespace MikeCars.Infraestructure.Repository.Repositories.Internal;

public abstract class BaseRepository
{
    protected string ConnectionString { get; private set; }

    public BaseRepository()
    {
        Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);
        ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    }
}
