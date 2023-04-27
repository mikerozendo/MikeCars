using Dapper;
using Microsoft.Data.SqlClient;
using MikeCars.Domain.Entities;
using MikeCars.Domain.Interfaces.Repositories;
using MikeCars.Infraestructure.Repository.Models;
using MikeCars.Infraestructure.Repository.Sql;

namespace MikeCars.Infraestructure.Repository.Repositories.Internal;

public class FuncionarioRepository : BaseRepository, IFuncionarioRepository
{
    public FuncionarioRepository() : base() { }

    public async Task Create(Funcionario funcionario)
    {
        string sql = FuncionarioSql.Create;
        FuncionarioModel funcionarioModel = new(funcionario);

        using var db = new SqlConnection(ConnectionString);
        await db.ExecuteAsync(sql, funcionarioModel);
    }
}
