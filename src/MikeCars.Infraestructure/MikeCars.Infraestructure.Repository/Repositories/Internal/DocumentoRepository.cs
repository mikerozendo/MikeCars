using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MikeCars.Domain.Interfaces.Repositories;
using MikeCars.Domain.ValueObjects;
using MikeCars.Dto.Models;
using MikeCars.Infraestructure.Repository.Context;

namespace MikeCars.Infraestructure.Repository.Repositories.Internal;

public class DocumentoRepository : IDocumentoRepository
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;
    public DocumentoRepository(IMapper mapper)
    {
        _mapper = mapper;
        _context = new();
    }

    public async Task<bool> AlreadyExistsAsync(Documento entity)
    {
        DocumentoModel model = _mapper.Map<DocumentoModel>(entity);

        DocumentoModel? result = await _context.Documentos.FirstOrDefaultAsync(x => model.Numero.Equals(x.Numero));

        return result is not null;
    }
}
