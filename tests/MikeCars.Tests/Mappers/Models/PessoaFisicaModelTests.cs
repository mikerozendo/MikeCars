//using AutoMapper;
//using MikeCars.Dto.Repository.Models;
//using MikeCars.Infraestructure.CrossCutting.Mappers;

//namespace MikeCars.Tests.Mappers.Models;

//public class PessoaFisicaModelTests
//{
//    private readonly IMapper _mapper;
//    private string CpfValidoUserSecret { get; }

//    public PessoaFisicaModelTests()
//    {
//        _mapper = new AutoMapperProfileBuilder().Build();
//        CpfValidoUserSecret = UserSecretsBuilder<DocumentoModelTests>.Build();
//    }
   
//    [Fact]
//    public void RetornaSucessoPessoaFisicaModel()
//    {
//        PessoaFisica entity = new(EnumTipoAgente.Representante, CpfValidoUserSecret)
//        {
//            Nome = "Michael",
//            Sobrenome = "Rozendo",
//            Nascimento = new DateTime(1998, 03, 11),
//            ContatoInfo = new()
//            {
//                Email = "mikerozendo@gmail.com",
//                TelefoneCelular = "11 9 4912-6483"
//            },
//            Endereco = new(EnumTipoEndereco.Residencial, EnumUf.SP)
//            {
//                Id = 1,
//                Logradouro = "Rua",
//                Bairro = "Campo Limpo",
//                Cidade = "São Paulo",
//                Numero = "123 BL A"
//            }
//        };

//        PessoaFisicaModel model = _mapper.Map<PessoaFisicaModel>(entity);

//        Assert.Equal(3, model.IdTipoAgente);
//        Assert.Equal("Michael Rozendo", model.Nome);
//        Assert.Equal(new DateTime(1998, 03, 11), model.Nascimento);
//        Assert.False(model.Endereco is null);
//        Assert.False(model.ContatoInfo is null);
//        Assert.False(model.Documento is null);
//        Assert.Equal("mikerozendo@gmail.com", model.ContatoInfo.Email);
//        Assert.Equal("11 9 4912-6483", model.ContatoInfo.TelefoneCelular);
//        Assert.Equal("Rua", model.Endereco.Logradouro);
//        Assert.Equal("Campo Limpo", model.Endereco.Bairro);
//        Assert.Equal("São Paulo", model.Endereco.Cidade);
//        Assert.Equal("123 BL A", model.Endereco.Numero);
//        Assert.Equal(1, model.Endereco.IdTipoEndereco);
//        Assert.Equal(EnumUf.SP.ToString(), model.Endereco.Uf);
//    }

//    [Fact]
//    public void RetornaSucessoPessoaFisica()
//    {
//        PessoaFisicaModel model = new()
//        {
//            Nome = "Michael Rozendo",
//            Nascimento = new DateTime(1998, 03, 11),
//            IdTipoAgente = 3,
//            IdContatoInfo = 5,
//            IdDocumento = 7,
//            ContatoInfo = new()
//            {
//                Id = 5,
//                Email = "mikerozendo@gmail.com",
//                TelefoneCelular = "11 9 4912-6483"
//            },
//            Endereco = new()
//            {
//                Id = 6,
//                Logradouro = "Rua",
//                Bairro = "Campo Limpo",
//                Cidade = "São Paulo",
//                Numero = "123 BL A",
//                IdTipoEndereco = 1,
//                Uf = "SP"
//            },
//            Documento = new()
//            {
//                Id = 7,
//                Numero = CpfValidoUserSecret,
//                IdTipoDocumento = 1
//            }
//        };

//        PessoaFisica entity = _mapper.Map<PessoaFisica>(model);

//        Assert.Equal(EnumTipoAgente.Representante, entity.EnumTipoAgente);
//        Assert.Equal("Michael", entity.Nome);
//        Assert.Equal("Rozendo", entity.Sobrenome);
//        Assert.Equal(new DateTime(1998, 03, 11), entity.Nascimento);
//        Assert.False(entity.Endereco is null);
//        Assert.False(entity.ContatoInfo is null);
//        Assert.False(entity.Documento is null);
//        Assert.Equal("mikerozendo@gmail.com", entity.ContatoInfo.Email);
//        Assert.Equal("11 9 4912-6483", entity.ContatoInfo.TelefoneCelular);
//        Assert.Equal(5, entity.ContatoInfo.Id);
//        Assert.Equal("Rua", entity.Endereco.Logradouro);
//        Assert.Equal(6, entity.Endereco.Id);
//        Assert.Equal("Campo Limpo", entity.Endereco.Bairro);
//        Assert.Equal("São Paulo", entity.Endereco.Cidade);
//        Assert.Equal("123 BL A", entity.Endereco.Numero);
//        Assert.Equal(EnumTipoEndereco.Residencial, entity.Endereco.EnumTipoEndereco);
//        Assert.Equal(EnumUf.SP, entity.Endereco.EnumUf);
//        Assert.Equal(7, entity.Documento.Id);
//        Assert.Equal(CpfValidoUserSecret, entity.Documento.Numero);
//    }
//}
