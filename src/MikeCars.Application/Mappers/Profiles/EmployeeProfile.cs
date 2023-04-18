using AutoMapper;
using MikeCars.Domain.Entities;
using MikeCars.Domain.Enums;
using MikeCars.Domain.Extentions;
using MikeCars.Domain.ValueObjects;
using MikeCars.Application.ViewModels;
using System.Runtime.CompilerServices;

namespace MikeCars.Application.Mappers.Profiles
{
    public static class EmployeeProfile
    {
        public static  MapperConfiguration CreateAutoMapperConfiguration(this MapperConfiguration mapperConfiguration)
        {
            return new(cfg =>
            {

                //cfg.CreateMap<EmployeeViewModel, Funcionario>()
                //    .ForMember(x => x.Nome, y => y.MapFrom(x => x.PessoaFisicaModel.Nome.Substring(0, x.PessoaFisicaModel.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
                //    .ForMember(x => x.Nome, y => y.MapFrom(x => x.FirstName))
                //    .ForMember(x => x.Sobrenome, y => y.MapFrom(x => x.FirstName))
                //    .ForMember(x => x.Nome, y => y.MapFrom(x => x.FirstName))
                //    .ForMember(x => x.Nome, y => y.MapFrom(x => x.FirstName))
                //    .ForMember(x => x.Nome, y => y.MapFrom(x => x.FirstName))
                //    .ForMember(x => x.Nome, y => y.MapFrom(x => x.FirstName))
                //    .ForMember(x => x.Sobrenome, y => y.MapFrom(x => x.PessoaFisicaModel.Nome.Substring(x.PessoaFisicaModel.Nome.Split(' ', StringSplitOptions.None)[0].Length).Trim()))
                //    .ForMember(x => x.Endereco, y => y.MapFrom(x => x.PessoaFisicaModel.EnderecoModel))
                //    .ForMember(x => x.ContatoInfo, y => y.MapFrom(x => x.PessoaFisicaModel.ContatoInfoModel))
                //    .ForMember(x => x.Documento, y => y.MapFrom(x => x.PessoaFisicaModel.DocumentoModel))
                //    .ConstructUsing(x => new(x.PessoaFisicaModel.DocumentoModel.Numero.GetCpfUnformattedValue()));
            });
        }
    }
}
