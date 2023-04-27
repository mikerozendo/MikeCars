using Dapper;
using Microsoft.Data.SqlClient;
using MikeCars.Domain.Interfaces.Repositories;
using MikeCars.Domain.ValueObjects;
using MikeCars.Infraestructure.Repository.Models;
using MikeCars.Infraestructure.Repository.Sql;

namespace MikeCars.Infraestructure.Repository.Repositories.Internal;

public class DocumentoRepository : BaseRepository, IDocumentoRepository
{
    public DocumentoRepository() : base() { }

    public async Task<bool> AlreadyExistsAsync(Documento entity)
    {
        string sqlQuery = DocumentoSql.AlreadyExists;

        using var db = new SqlConnection(ConnectionString);
        var dbReturn = await db.QueryFirstOrDefaultAsync<DocumentoModel>(sqlQuery, new { documentNumber = entity.NumeroFormatado });

        return dbReturn is not null;
    }
}
