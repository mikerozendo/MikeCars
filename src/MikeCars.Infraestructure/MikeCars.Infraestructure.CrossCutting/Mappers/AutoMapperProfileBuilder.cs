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
                .ForMember(x => x.PessoaFisicaModel.IdTipoAgente, y => y.MapFrom(y => (int)y.EnumTipoAgente))
                .ForMember(x => x.PessoaFisicaModel.Nome, y => y.MapFrom(x => String.Concat(x.Nome, " ", x.Sobrenome)))
                .ForMember(x => x.PessoaFisicaModel.EnderecoModel, y => y.MapFrom(x => x.Endereco))
                .ForMember(x => x.PessoaFisicaModel.ContatoInfoModel, y => y.MapFrom(x => x.ContatoInfo))
                .ForMember(x => x.PessoaFisicaModel.DocumentoModel, y => y.MapFrom(x => x.Documento))
                .ForMember(x => x.PessoaJuridicaModel, y => y.MapFrom(x => x.Empresa))
                .ForMember(x => x.PessoaFisicaModel.IdContatoInfoModel, y => y.Ignore())
                .ForMember(x => x.PessoaFisicaModel.IdDocumentoModel, y => y.Ignore())
                .ForMember(x => x.PessoaFisicaModel.IdEnderecoModel, y => y.Ignore());

            cfg.CreateMap<RepresentanteModel, Representante>()
                .ForMember(x => x.EnumTipoAgente, y => y.MapFrom(y => (EnumTipoAgente)y.PessoaFisicaModel.IdTipoAgente))
                .ForMember(x => x.Nome, y => y.MapFrom(x => x.PessoaFisicaModel.Nome.Substring(0, x.PessoaFisicaModel.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
                .ForMember(x => x.Sobrenome, y => y.MapFrom(x => x.PessoaFisicaModel.Nome.Substring(x.PessoaFisicaModel.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
                .ForMember(x => x.Endereco, y => y.MapFrom(x => x.PessoaFisicaModel.EnderecoModel))
                .ForMember(x => x.ContatoInfo, y => y.MapFrom(x => x.PessoaFisicaModel.ContatoInfoModel))
                .ForMember(x => x.Documento, y => y.MapFrom(x => x.PessoaFisicaModel.DocumentoModel))
                .ForMember(x => x.Empresa, y => y.Ignore())
                .ConstructUsing(x => new(x.PessoaFisicaModel.DocumentoModel.Numero,
                                x.PessoaJuridicaModel.DocumentoModel.Numero,
                                (EnumTipoAgente)x.PessoaJuridicaModel.AgenteModel.IdTipoAgente));

            cfg.CreateMap<PessoaFisicaModel, PessoaFisica>()
                //.ForMember(x => x.EnumTipoAgente, y => y.MapFrom(y => y.IdTipoAgente))
                .ForMember(x => x.Nome, y => y.MapFrom(x => x.Nome.Substring(0, x.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
                .ForMember(x => x.Sobrenome, y => y.MapFrom(x => x.Nome.Substring(x.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
                //.ForMember(x => x.Endereco, y => y.MapFrom(x => x.Endereco))
                //.ForMember(x => x.ContatoInfo, y => y.MapFrom(x => x.ContatoInfo))
                //.ForMember(x => x.Documento, y => y.MapFrom(x => x.Documento))
                .ConstructUsing(x => new PessoaFisica((EnumTipoAgente)x.AgenteModel.IdTipoAgente, (EnumTipoDocumento)x.AgenteModel.DocumentoModel.IdTipoDocumento, x.AgenteModel.DocumentoModel.Numero.GetCpfUnformattedValue()));

            cfg.CreateMap<PessoaJuridica, PessoaJuridicaModel>()
                .ForMember(x => x.AgenteModel.IdTipoAgente, y => y.MapFrom(y => (int)y.EnumTipoAgente))
                .ForMember(x => x.RepresentanteModel, y => y.MapFrom(x => x.Representante))
                .ForMember(x => x.AgenteModel.EnderecoModel, y => y.MapFrom(x => x.Endereco))
                .ForMember(x => x.AgenteModel.DocumentoModel, y => y.MapFrom(x => x.Documento))
                .ForMember(x => x.AgenteModel.ContatoInfoModel, y => y.MapFrom(x => x.ContatoInfo))
                .ForMember(x => x.AgenteModel.IdContatoInfoModel, y => y.Ignore())
                .ForMember(x => x.AgenteModel.IdDocumentoModel, y => y.Ignore())
                .ForMember(x => x.AgenteModel.IdEnderecoModel, y => y.Ignore())
                //.ForMember(x => x.AgenteModel.IdPessoaRepresentanteModel, y => y.Ignore())
                .DisableCtorValidation();

            cfg.CreateMap<PessoaJuridicaModel, PessoaJuridica>()
                .ForMember(x => x.EnumTipoAgente, y => y.MapFrom(y => y.AgenteModel.IdTipoAgente))
                .ForMember(x => x.Representante, y => y.MapFrom(x => x.RepresentanteModel))
                .ForMember(x => x.Endereco, y => y.MapFrom(x => x.AgenteModel.EnderecoModel))
                .ForMember(x => x.ContatoInfo, y => y.MapFrom(x => x.AgenteModel.ContatoInfoModel))
                .ForMember(x => x.Documento, y => y.MapFrom(x => x.DocumentoModel))
                .ConstructUsing(x => new(x.RepresentanteModel.PessoaFisicaModel.DocumentoModel.Numero.GetCpfUnformattedValue(), 
                                x.DocumentoModel.Numero.GetCnpjUnformattedValue(), (EnumTipoAgente)x.AgenteModel.IdTipoAgente));

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
