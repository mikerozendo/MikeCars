using FluentResults;
using MikeCars.Domain.Entities;
using MikeCars.Domain.Extentions;
using MikeCars.Domain.Interfaces.Services;

namespace MikeCars.Domain.Services;

public class FuncionarioService : IFuncionarioService
{

    private readonly IPessoaFisicaService _pessoaFisicaService;

    public FuncionarioService(IPessoaFisicaService pessoaFisicaService)
    {
        _pessoaFisicaService = pessoaFisicaService;
    }

    public async Task<Result> Create(Funcionario employee)
    {
        var result = await _pessoaFisicaService.CreateAsync(employee);

        if (result.IsSuccess)
        {
            //CreAte employee in db;

            return Result.Ok();
        }
        else
        {
            var error = result.GetErrorMessage();
            return Result.Fail(error);  
        }
    }

    public Task<Result> Get()
    {
        throw new NotImplementedException();
    }
}
