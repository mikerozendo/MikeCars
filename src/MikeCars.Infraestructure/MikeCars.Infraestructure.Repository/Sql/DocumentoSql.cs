namespace MikeCars.Infraestructure.Repository.Sql;

internal static class DocumentoSql
{
    internal const string AlreadyExists = @"
        SELECT
	        TOP 1 *
        FROM [T_DOCUMENTO]
        WHERE Numero = @documentNumber
    ";
}
