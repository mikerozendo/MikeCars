using FluentResults;
using MikeCars.Domain.Entities;
using MikeCars.Domain.Extentions;
using MikeCars.Domain.Interfaces.Repositories;
using MikeCars.Domain.Interfaces.Services;

namespace MikeCars.Domain.Services;

public class FuncionarioService : IFuncionarioService
{

    private readonly IPessoaFisicaService _pessoaFisicaService;
    private readonly IFuncionarioRepository _funcionarioRepository;

    public FuncionarioService(IPessoaFisicaService pessoaFisicaService, IFuncionarioRepository funcionarioRepository)
    {
        _pessoaFisicaService = pessoaFisicaService;
        _funcionarioRepository = funcionarioRepository;
    }

    public async Task<Result> Create(Funcionario employee)
    {
        var personResult = await _pessoaFisicaService.CreateAsync(employee);
        var employeeResult = await _funcionarioRepository.Create(employee);
        if (personResult.IsSuccess)
        {
            //CreAte employee in db;

            return Result.Ok();
        }
        else
        {
            var error = personResult.GetErrorMessage();
            return Result.Fail(error);  
        }
    }

    public Task<Result> Get()
    {
        throw new NotImplementedException();
    }
}
