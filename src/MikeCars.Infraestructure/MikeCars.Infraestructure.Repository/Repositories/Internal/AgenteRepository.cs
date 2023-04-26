using FluentResults;
using MikeCars.Domain.Entities;
using MikeCars.Domain.Interfaces.Repositories;
using MikeCars.Infraestructure.Repository.Models;

namespace MikeCars.Infraestructure.Repository.Repositories.Internal
{
    //public class AgenteRepository : IAgenteRepository
    //{
    //    public async Task<Result<int>> CreateAsync(PessoaFisica entity)
    //    {
    //        PessoaFisicaModel model = entity.ToModel();
    //        await _context.Pessoas.AddAsync(model);
    //        await _context.SaveChangesAsync();
    //        return Result.Ok(model.PessoaFisicaModelId);


    //        //PessoaFisicaModel model = entity.ToModel();
    //        //await _context.Pessoas.AddAsync(model);
    //        //await _context.SaveChangesAsync();
    //        //return Result.Ok(model.PessoaFisicaModelId);
    //    }
    //}
}
