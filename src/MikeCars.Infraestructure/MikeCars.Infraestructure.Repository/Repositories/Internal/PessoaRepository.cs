//using MikeCars.Domain.Interfaces.Repositories;
//using MikeCars.Domain.Entities;
//using FluentResults;
//using AutoMapper;
//using MikeCars.Infraestructure.Repository.Context;
//using MikeCars.Dto.Models;

//namespace MikeCars.Infraestructure.Repository.Repositories.Internal;

//public class PessoaRepository : IPessoaFisicaRepository
//{
//    private readonly IMapper _mapper;
//    private readonly AppDbContext _context;
//    public PessoaRepository(IMapper mapper)
//    {
//        _mapper = mapper;
//        _context = new();
//    }

//    public async Task<Result<int>> CreateAsync(PessoaFisica entity)
//    {
//        PessoaFisicaModel model = _mapper.Map<PessoaFisicaModel>(entity);
//        await _context.Pessoas.AddAsync(model);
//        await _context.SaveChangesAsync();
//        return Result.Ok(entity.Id);
//    }
//}
