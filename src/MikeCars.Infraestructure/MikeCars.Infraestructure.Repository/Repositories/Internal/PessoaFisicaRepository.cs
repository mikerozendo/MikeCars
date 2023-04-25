using MikeCars.Domain.Interfaces.Repositories;
using MikeCars.Domain.Entities;
using FluentResults;
using MikeCars.Infraestructure.Repository.Context;
using MikeCars.Infraestructure.Repository.Mappers;
using MikeCars.Infraestructure.Repository.Models;

namespace MikeCars.Infraestructure.Repository.Repositories.Internal;

public class PessoaFisicaRepository : IPessoaFisicaRepository
{
    private readonly AppDbContext _context;
    public PessoaFisicaRepository()
    {
        _context = new();
    }

    public async Task<Result<int>> CreateAsync(PessoaFisica entity)
    {
        PessoaFisicaModel model = entity.ToModel();
        await _context.Pessoas.AddAsync(model);
        await _context.SaveChangesAsync();
        return Result.Ok(model.PessoaFisicaModelId);
    }
}
