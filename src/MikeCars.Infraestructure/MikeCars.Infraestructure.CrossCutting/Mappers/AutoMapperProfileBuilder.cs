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
                .ForMember(x => x.IdTipoAgente, y => y.MapFrom(y => (int)y.EnumTipoAgente))
                .ForMember(x => x.Nome, y => y.MapFrom(x => String.Concat(x.Nome, " ", x.Sobrenome)))
                .ForMember(x => x.EnderecoModel, y => y.MapFrom(x => x.Endereco))
                .ForMember(x => x.ContatoInfoModel, y => y.MapFrom(x => x.ContatoInfo))
                .ForMember(x => x.DocumentoModel, y => y.MapFrom(x => x.Documento))
                .ForMember(x => x.PessoaJuridicaModel, y => y.MapFrom(x => x.Empresa))
                .ForMember(x => x.IdContatoInfoModel, y => y.Ignore())
                .ForMember(x => x.IdDocumentoModel, y => y.Ignore())
                .ForMember(x => x.IdEnderecoModel, y => y.Ignore());

            cfg.CreateMap<RepresentanteModel, Representante>()
                .ForMember(x => x.EnumTipoAgente, y => y.MapFrom(y => (EnumTipoAgente)y.IdTipoAgente))
                .ForMember(x => x.Nome, y => y.MapFrom(x => x.Nome.Substring(0, x.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
                .ForMember(x => x.Sobrenome, y => y.MapFrom(x => x.Nome.Substring(x.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
                .ForMember(x => x.Endereco, y => y.MapFrom(x => x.EnderecoModel))
                .ForMember(x => x.ContatoInfo, y => y.MapFrom(x => x.ContatoInfoModel))
                .ForMember(x => x.Documento, y => y.MapFrom(x => x.DocumentoModel))
                .ForMember(x => x.Empresa, y => y.Ignore())
                .ConstructUsing(
                                x => new(x.DocumentoModel.Numero,
                                x.PessoaJuridicaModel.DocumentoModel.Numero,
                                (EnumTipoAgente)x.PessoaJuridicaModel.IdTipoAgente));

            //cfg.CreateMap<PessoaFisicaModel, PessoaFisica>()
            //    //.ForMember(x => x.EnumTipoAgente, y => y.MapFrom(y => y.IdTipoAgente))
            //    .ForMember(x => x.Nome, y => y.MapFrom(x => x.Nome.Substring(0,x.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
            //    .ForMember(x => x.Sobrenome, y => y.MapFrom(x => x.Nome.Substring(x.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
            //    //.ForMember(x => x.Endereco, y => y.MapFrom(x => x.Endereco))
            //    //.ForMember(x => x.ContatoInfo, y => y.MapFrom(x => x.ContatoInfo))
            //    //.ForMember(x => x.Documento, y => y.MapFrom(x => x.Documento))
            //    .ConstructUsing(x => new PessoaFisica((EnumTipoAgente)x.AgenteModel.IdTipoAgente, (EnumTipoDocumento)x.AgenteModel.DocumentoModel.IdTipoDocumento,x.AgenteModel.DocumentoModel.Numero.GetCpfUnformattedValue()));

            cfg.CreateMap<PessoaJuridica, PessoaJuridicaModel>()
                .ForMember(x => x.IdTipoAgente, y => y.MapFrom(y => (int)y.EnumTipoAgente))
                .ForMember(x => x.RepresentanteModel, y => y.MapFrom(x => x.Representante))
                .ForMember(x => x.EnderecoModel, y => y.MapFrom(x => x.Endereco))
                .ForMember(x => x.DocumentoModel, y => y.MapFrom(x => x.Documento))
                .ForMember(x => x.ContatoInfoModel, y => y.MapFrom(x => x.ContatoInfo))
                .ForMember(x => x.IdContatoInfoModel, y => y.Ignore())
                .ForMember(x => x.IdDocumentoModel, y => y.Ignore())
                .ForMember(x => x.IdEnderecoModel, y => y.Ignore())
                .ForMember(x => x.IdPessoaRepresentanteModel, y => y.Ignore())
                .DisableCtorValidation();

            cfg.CreateMap<PessoaJuridicaModel, PessoaJuridica>()
                .ForMember(x => x.EnumTipoAgente, y => y.MapFrom(y => y.IdTipoAgente))
                .ForMember(x => x.Representante, y => y.MapFrom(x => x.RepresentanteModel))
                .ForMember(x => x.Endereco, y => y.MapFrom(x => x.EnderecoModel))
                .ForMember(x => x.ContatoInfo, y => y.MapFrom(x => x.ContatoInfoModel))
                .ForMember(x => x.Documento, y => y.MapFrom(x => x.DocumentoModel))
                .ConstructUsing(x => new(x.RepresentanteModel.DocumentoModel.Numero.GetCpfUnformattedValue(), x.DocumentoModel.Numero.GetCnpjUnformattedValue(), (EnumTipoAgente)x.IdTipoAgente));

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
