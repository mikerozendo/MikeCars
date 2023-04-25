using Microsoft.EntityFrameworkCore;
using MikeCars.Domain.Interfaces.Repositories;
using MikeCars.Domain.ValueObjects;
using MikeCars.Infraestructure.Repository.Context;
using MikeCars.Infraestructure.Repository.Mappers;
using MikeCars.Infraestructure.Repository.Models;

namespace MikeCars.Infraestructure.Repository.Repositories.Internal;

public class DocumentoRepository : IDocumentoRepository
{
    private readonly AppDbContext _context;
    public DocumentoRepository()
    {
        _context = new();
    }

    public async Task<bool> AlreadyExistsAsync(Documento entity)
    {
        DocumentoModel model = entity.ToModel();   

        DocumentoModel? result = await _context.Documentos.FirstOrDefaultAsync(x => model.Numero.Equals(x.Numero));

        return result is not null;
    }
}
