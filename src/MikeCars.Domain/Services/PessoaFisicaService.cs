using FluentResults;
using MikeCars.Domain.Entities;
using MikeCars.Domain.Interfaces.Repositories;
using MikeCars.Domain.Interfaces.Services;

namespace MikeCars.Domain.Services
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IDocumentoRepository _documentoRepository;
        private readonly IPessoaFisicaRepository _pessoaRepository;

        public PessoaFisicaService(IDocumentoRepository documentoRepository, IPessoaFisicaRepository pessoaRepository)
        {
            _documentoRepository = documentoRepository;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Result<int>> CreateAsync(PessoaFisica pessoa)
        {
            pessoa.Documento.Builder();

            if (pessoa.Documento.Valido)
            {
                var documentoExiste = await _documentoRepository.AlreadyExistsAsync(pessoa.Documento);

                if (!documentoExiste)
                {
                    return await _pessoaRepository.CreateAsync(pessoa);
                }

                return Result.Fail<int>("Documento já cadastrado na base");
            }

            return Result.Fail<int>("Informe um documento valido.");
        }
    }
}
