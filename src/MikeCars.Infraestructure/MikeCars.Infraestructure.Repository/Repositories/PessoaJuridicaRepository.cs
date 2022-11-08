using AutoMapper;
using FluentResults;
using MikeCars.Domain.Entities;
using MikeCars.Domain.Interfaces.Repositories;
using MikeCars.Dto.Repository.Models;
using MikeCars.Infraestructure.Repository.Context;

namespace MikeCars.Infraestructure.Repository.Repositories;

public class PessoaJuridicaRepository : IPessoaJuridicaRepository
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;
    public PessoaJuridicaRepository(IMapper mapper)
    {
        _mapper = mapper;
        _context = new();
    }

    public async Task<Result<int>> CreateAsync(PessoaJuridica entity)
    {
        PessoaJuridicaModel model = _mapper.Map<PessoaJuridicaModel>(entity);
        await _context.Empresas.AddAsync(model);
        await _context.SaveChangesAsync();
        return Result.Ok(model.Id);
    }
}
