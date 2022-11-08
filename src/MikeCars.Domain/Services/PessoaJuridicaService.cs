using FluentResults;
using MikeCars.Domain.Entities;
using MikeCars.Domain.Extentions;
using MikeCars.Domain.Interfaces.Repositories;
using MikeCars.Domain.Interfaces.Services;

namespace MikeCars.Domain.Services;

public class PessoaJuridicaService : IPessoaJuridicaService
{
    private readonly IDocumentoRepository _documentoRepository;
    private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;
    private readonly IPessoaFisicaService _pessoaFisicaService;
    public PessoaJuridicaService(IDocumentoRepository documentoRepository, IPessoaJuridicaRepository pessoaJuridicaRepository, IPessoaFisicaService pessoaFisicaService)
    {
        _documentoRepository = documentoRepository;
        _pessoaJuridicaRepository = pessoaJuridicaRepository;
        _pessoaFisicaService = pessoaFisicaService;
    }

    public async Task<Result<int>> CreateAsync(PessoaJuridica empresa)
    {
        empresa.Documento.Builder();

        if (empresa.Documento.Valido)
        {
            var documentoExiste = await _documentoRepository.AlreadyExistsAsync(empresa.Documento);

            if (!documentoExiste)
            {
                var representeanteResult = await _pessoaFisicaService.CreateAsync(empresa.Representante);
                if (representeanteResult.IsSuccess)
                {
                    empresa.Representante.Id = representeanteResult.Value;
                    return await _pessoaJuridicaRepository.CreateAsync(empresa);
                }

                return Result.Fail<int>($"Falha ao cadastrar representante: {representeanteResult.GetErrorMessage()}");
            }

            return Result.Fail<int>("Empresa já cadastrada na base");
        }

        return Result.Fail<int>("Informe um documento valido");
    }
}
