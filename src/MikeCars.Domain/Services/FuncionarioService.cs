using FluentResults;
using MikeCars.Domain.Entities;
using MikeCars.Domain.Interfaces.Repositories;
using MikeCars.Domain.Interfaces.Services;

namespace MikeCars.Domain.Services;

public class FuncionarioService : IFuncionarioService
{
    private readonly IDocumentoRepository _documentoRepository;
    private readonly IFuncionarioRepository _funcionarioRepository;

    public FuncionarioService(IDocumentoRepository documentoRepository, IFuncionarioRepository funcionarioRepository)
    {
        _documentoRepository = documentoRepository;
        _funcionarioRepository = funcionarioRepository;
    }

    public async Task<Result> Create(Funcionario employee)
    {
        try
        {
            employee.Documento.Builder();

            if (employee.Documento.Valido)
            {
                var documentoExiste = await _documentoRepository.AlreadyExistsAsync(employee.Documento);

                if (!documentoExiste)
                {
                    await _funcionarioRepository.Create(employee);
                    return Result.Ok();
                }
            }

            return Result.Fail("Por favor, informe um documento valido!");
        }
        catch (Exception ex)
        {

            return Result.Fail($"Falha ao tentar cadastrar funcionario. {ex}");
        }

    }

    public Task<Result> Get()
    {
        throw new NotImplementedException();
    }
}
