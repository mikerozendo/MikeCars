using FluentResults;
using MikeCars.Domain.Entities;
using MikeCars.Domain.Interfaces.Services;

namespace MikeCars.Domain.Services;

public class PessoaService 
{
    private readonly IPessoaFisicaService _pessoaFisicaService;
    private readonly IPessoaJuridicaService _pessoaJuridicaService;

    public PessoaService(IPessoaFisicaService pessoaFisicaService, IPessoaJuridicaService pessoaJuridicaService)
    {
        _pessoaFisicaService = pessoaFisicaService;
        _pessoaJuridicaService = pessoaJuridicaService;
    }

    public async Task<Result<int>> CreateAsync(Agente pessoa)
    {
        PessoaJuridica? empresa = pessoa as PessoaJuridica;
        if (empresa is not null)
            return await _pessoaJuridicaService.CreateAsync(empresa);

        PessoaFisica? pessoaFisica = pessoa as PessoaFisica;
        if (pessoaFisica is not null)
            return await _pessoaFisicaService.CreateAsync(pessoaFisica);

        return Result.Fail<int>("");
    }
}
