using AutoMapper;
using MikeCars.Domain.Entities;
using MikeCars.Domain.Enums;
using MikeCars.Domain.Extentions;
using MikeCars.Domain.ValueObjects;
using MikeCars.Dto.Repository.Models;

namespace MikeCars.Infraestructure.CrossCutting.Mappers;

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
            cfg.CreateMap<Representante, RepresentanteModel>()
                .ForMember(x => x.PessoaJuridicaModelId, y => y.Ignore())
                .ForMember(x => x.PessoaFisicaModel, y => y.Ignore())
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
                .ConstructUsing(x => new(x.PessoaFisicaModel.DocumentoModel.Numero,
                                x.PessoaJuridicaModel.DocumentoModel.Numero,
                                (EnumTipoAgente)x.PessoaJuridicaModel.AgenteModel.IdTipoAgente));

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

            cfg.CreateMap<PessoaJuridica, PessoaJuridicaModel>()
                .ForMember(x => x.RepresentanteModel, y => y.MapFrom(x => x.Representante))
                .ForMember(x => x.IdAgenteModel, y => y.Ignore())
                .ForMember(x => x.IdPessoaRepresentanteModel, y => y.Ignore())
                .ForMember(x => x.DocumentoModelId, y => y.Ignore())
                .ForMember(x => x.AgenteModel, y => y.Ignore())
                .ForMember(x => x.DocumentoModel, y => y.Ignore())
                .ForMember(x => x.RepresentanteModel, y => y.Ignore())
                .DisableCtorValidation();

            cfg.CreateMap<PessoaJuridicaModel, PessoaJuridica>()
                .ForMember(x => x.EnumTipoAgente, y => y.MapFrom(y => y.AgenteModel.IdTipoAgente))
                .ForMember(x => x.Representante, y => y.MapFrom(x => x.RepresentanteModel))
                .ForMember(x => x.Endereco, y => y.MapFrom(x => x.AgenteModel.EnderecoModel))
                .ForMember(x => x.ContatoInfo, y => y.MapFrom(x => x.AgenteModel.ContatoInfoModel))
                .ForMember(x => x.Documento, y => y.MapFrom(x => x.DocumentoModel))
                .ConstructUsing(x => new(x.RepresentanteModel.PessoaFisicaModel.DocumentoModel.Numero.GetCpfUnformattedValue(),
                                x.DocumentoModel.Numero.GetCnpjUnformattedValue(), (EnumTipoAgente)x.AgenteModel.IdTipoAgente));


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
                .DisableCtorValidation();

            cfg.CreateMap<EnderecoModel, Endereco>()
                .ForMember(x => x.EnumTipoEndereco, y => y.MapFrom(y => y.IdTipoEndereco))
                .ForMember(x => x.EnumUf, y => y.MapFrom(x => (EnumUf)Enum.Parse(typeof(EnumUf), x.Uf)))
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
        });
    }
}
