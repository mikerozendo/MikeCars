using MikeCars.Domain.Interfaces.Repositories;
using MikeCars.Domain.Entities;
using FluentResults;
using AutoMapper;
using MikeCars.Dto.Repository.Models;
using MikeCars.Infraestructure.Repository.Context;

namespace MikeCars.Infraestructure.Repository;

public class PessoaRepository : IPessoaFisicaRepository
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;
    public PessoaRepository(IMapper mapper)
    {
        _mapper = mapper;
        _context = new();
    }

    public async Task<Result<int>> CreateAsync(PessoaFisica entity)
    {
        PessoaFisicaModel model = _mapper.Map<PessoaFisicaModel>(entity);
        await _context.Pessoas.AddAsync(model);
        await _context.SaveChangesAsync();
        return Result.Ok(entity.Id);
    }
}
