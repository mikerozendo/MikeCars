using MikeCars.Domain.ValueObjects;
using MikeCars.Infraestructure.Repository.Models;

namespace MikeCars.Infraestructure.Repository.Mappers;

public static class DocumentoMapper
{
    public static DocumentoModel ToModel(this Documento documento)
    {
        var documentoModel = new DocumentoModel()
        {
            Numero = documento.NumeroFormatado
        };

        return documentoModel;
    }
}
