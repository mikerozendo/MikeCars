using MikeCars.Domain.Entities;
using MikeCars.Infraestructure.Repository.Models;

namespace MikeCars.Infraestructure.Repository.Mappers;

public static class PessoaFisicaMapper
{
    public static PessoaFisicaModel ToModel(this PessoaFisica pessoaFisica)
    {
        var pessoa = new PessoaFisicaModel()
        {
            AgenteModel = new AgenteModel()
            {
                IdTipoAgente = (int)pessoaFisica.EnumTipoAgente,

                ContatoInfoModel = new ContatoInfoModel()
                {
                    ContatoInfoModelId = pessoaFisica.ContatoInfo.Id,
                    Email = pessoaFisica.ContatoInfo.Email,
                    TelefoneCelular = pessoaFisica.ContatoInfo.TelefoneCelular,
                    TelefoneResidencial = pessoaFisica.ContatoInfo.TelefoneResidencial,
                },
                DocumentoModel = new DocumentoModel()
                {
                    DocumentoModelId = pessoaFisica.Documento.Id,
                    IdTipoDocumento = (int)pessoaFisica.Documento.EnumTipoDocumento,
                    Numero = pessoaFisica.Documento.NumeroFormatado
                },
                EnderecoModel = new EnderecoModel()
                {
                    EnderecoModelId = pessoaFisica.Endereco.Id,
                    Bairro = pessoaFisica.Endereco.Bairro,
                    Cidade = pessoaFisica.Endereco.Cidade,
                    Logradouro = pessoaFisica.Endereco.Logradouro,
                    Numero = pessoaFisica.Endereco.Numero,
                    Uf = pessoaFisica.Endereco.EnumUf.ToString(),
                    PontoReferencia = pessoaFisica.Endereco.PontoReferencia
                },
            },

            Nascimento = pessoaFisica.Nascimento,
            Nome = pessoaFisica.Nome,
            Sobrenome = pessoaFisica.Sobrenome,
        };

        return pessoa;
    }
}
