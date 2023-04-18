using AutoMapper;
using MikeCars.Domain.Entities;
using MikeCars.Domain.Enums;
using MikeCars.Domain.Extentions;
using MikeCars.Domain.ValueObjects;
using MikeCars.Dto.Models;

namespace MikeCars.Application.Mappers;

public class AutoMapperProfileBuilder : Profile
{
    public IMapper Build()
    {
        return CreateAutoMapperConfiguration().CreateMapper();
    }

    public MapperConfiguration CreateAutoMapperConfiguration()
    {
        return new(cfg =>
        {
            cfg.CreateMap<Agente, AgenteModel>()
                .ForMember(x => x.EnderecoModel, y => y.MapFrom(x => x.Endereco))
                .ForMember(x => x.IdTipoAgente, y => y.MapFrom(x => (int)x.EnumTipoAgente))
                .ForMember(x => x.DocumentoModel, y => y.MapFrom(x => x.Documento))
                .ForMember(x => x.ContatoInfoModel, y => y.MapFrom(x => x.ContatoInfo))
                .ForMember(x => x.IdContatoInfoModel, y => y.Ignore())
                .ForMember(x => x.IdDocumentoModel, y => y.Ignore())
                .ForMember(x => x.IdEnderecoModel, y => y.Ignore())
                .ReverseMap();

            cfg.CreateMap<ContatoInfo, ContatoInfoModel>()
                .ForMember(x => x.IdAgente, y => y.Ignore())
                .ForMember(x => x.AgenteModel, y => y.Ignore())
                .ReverseMap();

            cfg.CreateMap<Endereco, EnderecoModel>()
                .ForMember(x => x.IdTipoEndereco, y => y.MapFrom(y => (int)y.EnumTipoEndereco))
                .ForMember(x => x.AgenteModel, y => y.Ignore())
                .ForMember(x => x.IdAgente, y => y.Ignore())
                .ForMember(x => x.Uf, y => y.MapFrom(y => Enum.GetName(typeof(EnumUf), y.EnumUf)))
                .ForMember(x => x.Cidade, y => y.MapFrom(x => x.Cidade))
                .DisableCtorValidation();

            cfg.CreateMap<EnderecoModel, Endereco>()
                .ForMember(x => x.EnumTipoEndereco, y => y.MapFrom(y => y.IdTipoEndereco))
                .ForMember(x => x.EnumUf, y => y.MapFrom(x => (EnumUf)Enum.Parse(typeof(EnumUf), x.Uf)))
                .ForMember(x => x.Cidade, y => y.MapFrom(x => x.Cidade))
                .DisableCtorValidation();

            cfg.CreateMap<Documento, DocumentoModel>()
                .ForMember(x => x.IdTipoDocumento, y => y.MapFrom(src => (int)src.EnumTipoDocumento))
                .ForMember(x => x.AgenteModel, y => y.Ignore())
                .ForMember(x => x.IdAgente, y => y.Ignore())
                .ForMember(x => x.Numero, y => y.MapFrom(x => x.NumeroFormatado));

            cfg.CreateMap<DocumentoModel, Documento>()
                .ForMember(x => x.EnumTipoDocumento, y => y.MapFrom(src => src.IdTipoDocumento))
                .ForMember(x => x.NumeroFormatado, y => y.MapFrom(x => x.Numero))
                .ForMember(x => x.Numero, y => y.MapFrom(x => x.Numero))
                .ForMember(x => x.Valido, y => y.Ignore())
                .ConstructUsing(x => new Documento(x.Id));

            cfg.CreateMap<PessoaFisica, PessoaFisicaModel>()
                .ForMember(x => x.IdTipoAgente, y => y.MapFrom(y => (int)y.EnumTipoAgente))
                .ForMember(x => x.Nome, y => y.MapFrom(x => String.Concat(x.Nome, " ", x.Sobrenome)))
                .ForMember(x => x.EnderecoModel, y => y.MapFrom(x => x.Endereco))
                .ForMember(x => x.ContatoInfoModel, y => y.MapFrom(x => x.ContatoInfo))
                .ForMember(x => x.DocumentoModel, y => y.MapFrom(x => x.Documento))
                .ForMember(x => x.IdContatoInfoModel, y => y.Ignore())
                .ForMember(x => x.IdDocumentoModel, y => y.Ignore())
                .ForMember(x => x.IdEnderecoModel, y => y.Ignore()).DisableCtorValidation();

            cfg.CreateMap<PessoaFisicaModel, PessoaFisica>()
                .ForMember(x => x.EnumTipoAgente, y => y.MapFrom(y => y.IdTipoAgente))
                .ForMember(x => x.Nome, y => y.MapFrom(x => x.Nome.Substring(0, x.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
                .ForMember(x => x.Sobrenome, y => y.MapFrom(x => x.Nome.Substring(x.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
                .ForMember(x => x.Endereco, y => y.MapFrom(x => x.EnderecoModel))
                .ForMember(x => x.ContatoInfo, y => y.MapFrom(x => x.ContatoInfoModel))
                .ForMember(x => x.Documento, y => y.MapFrom(x => x.DocumentoModel)).DisableCtorValidation();

            cfg.CreateMap<Representante, RepresentanteModel>()
                .ForMember(x => x.PessoaJuridicaModelId, y => y.Ignore())
                .ForPath(x => x.PessoaFisicaModel.Nascimento, y => y.MapFrom(x => x.Nascimento))
                .ForPath(x => x.PessoaFisicaModel.Nome, y =>y.MapFrom(x => String.Concat(x.Nome, " ", x.Sobrenome)))
                .ForPath(x => x.PessoaFisicaModel.IdTipoAgente, y =>y.MapFrom(x => (int)x.EnumTipoAgente))
                .ForPath(x => x.PessoaFisicaModel.ContatoInfoModel.Email, y =>y.MapFrom(x => x.ContatoInfo.Email))
                .ForPath(x => x.PessoaFisicaModel.ContatoInfoModel.TelefoneCelular, y =>y.MapFrom(x => x.ContatoInfo.TelefoneCelular))
                .ForPath(x => x.PessoaFisicaModel.ContatoInfoModel.TelefoneResidencial, y =>y.MapFrom(x => x.ContatoInfo.TelefoneResidencial))
                .ForPath(x => x.PessoaFisicaModel.DocumentoModel.Numero, y =>y.MapFrom(x => x.Documento.Numero))
                .ForPath(x => x.PessoaFisicaModel.DocumentoModel.IdTipoDocumento, y =>y.MapFrom(x => (int)x.Documento.EnumTipoDocumento))
                .ForPath(x => x.PessoaFisicaModel.EnderecoModel.Logradouro, y =>y.MapFrom(x => x.Endereco.Logradouro))
                .ForPath(x => x.PessoaFisicaModel.EnderecoModel.Numero, y =>y.MapFrom(x => x.Endereco.Numero))
                .ForPath(x => x.PessoaFisicaModel.EnderecoModel.Bairro, y =>y.MapFrom(x => x.Endereco.Bairro))
                .ForPath(x => x.PessoaFisicaModel.EnderecoModel.Cidade, y =>y.MapFrom(x => x.Endereco.Cidade))
                .ForPath(x => x.PessoaFisicaModel.EnderecoModel.Uf, y =>y.MapFrom(x => x.Endereco.EnumUf.ToString()))
                .ForPath(x => x.PessoaFisicaModel.EnderecoModel.IdTipoEndereco, y =>y.MapFrom(x => (int)x.Endereco.EnumTipoEndereco))
                .ForMember(x => x.PessoaFisicaModelId, y => y.Ignore())
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.PessoaJuridicaModel, y => y.MapFrom(x => x.Empresa));

            cfg.CreateMap<RepresentanteModel, Representante>()
                .ForMember(x => x.Nome, y => y.MapFrom(x => x.PessoaFisicaModel.Nome.Substring(0, x.PessoaFisicaModel.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
                .ForMember(x => x.Sobrenome, y => y.MapFrom(x => x.PessoaFisicaModel.Nome.Substring(x.PessoaFisicaModel.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
                .ForMember(x => x.Endereco, y => y.MapFrom(x => x.PessoaFisicaModel.EnderecoModel))
                .ForMember(x => x.ContatoInfo, y => y.MapFrom(x => x.PessoaFisicaModel.ContatoInfoModel))
                .ForMember(x => x.Documento, y => y.MapFrom(x => x.PessoaFisicaModel.DocumentoModel))
                .ForMember(x => x.Empresa, y => y.MapFrom(x => x.PessoaJuridicaModel))
                .ForMember(x => x.EnumTipoAgente, y => y.MapFrom(y => y.PessoaFisicaModel.IdTipoAgente))
                .ForMember(x => x.Nascimento, y => y.MapFrom(y => y.PessoaFisicaModel.Nascimento))
                .ConstructUsing(x => new(x.PessoaFisicaModel.DocumentoModel.Numero.GetCpfUnformattedValue()));

            cfg.CreateMap<PessoaJuridica, PessoaJuridicaModel>()
                .ForMember(x => x.RepresentanteModel, y => y.MapFrom(x => x.Representante))
                .ForMember(x => x.IdTipoAgente, y => y.MapFrom(x => (int)x.EnumTipoAgente))
                .ForMember(x => x.IdPessoaRepresentanteModel, y => y.Ignore())
                .ForMember(x => x.IdEnderecoModel, y => y.Ignore())
                .ForMember(x => x.IdContatoInfoModel, y => y.Ignore())
                .ForMember(x => x.IdDocumentoModel, y => y.Ignore())
                .ForMember(x => x.DocumentoModel, y => y.MapFrom(x => x.Documento))
                .ForMember(x => x.RepresentanteModel, y => y.MapFrom(x => x.Representante))
                .ForMember(x => x.EnderecoModel, y => y.MapFrom(x => x.Endereco))
                .ForMember(x => x.ContatoInfoModel, y => y.MapFrom(x => x.ContatoInfo))
                .DisableCtorValidation();

            cfg.CreateMap<PessoaJuridicaModel, PessoaJuridica>()
                .ForMember(x => x.EnumTipoAgente, y => y.MapFrom(y => y.IdTipoAgente))
                .ForMember(x => x.Representante, y => y.MapFrom(x => x.RepresentanteModel))
                .ForMember(x => x.Endereco, y => y.MapFrom(x => x.EnderecoModel))
                .ForMember(x => x.ContatoInfo, y => y.MapFrom(x => x.ContatoInfoModel))
                .ForMember(x => x.Documento, y => y.MapFrom(x => x.DocumentoModel))
                .ConstructUsing(x => new(x.DocumentoModel.Numero.GetCnpjUnformattedValue(), (EnumTipoAgente)x.IdTipoAgente));
        });
    }
}
