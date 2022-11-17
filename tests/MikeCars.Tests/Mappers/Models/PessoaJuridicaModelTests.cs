//using AutoMapper;
//using MikeCars.Dto.Repository.Models;
//using MikeCars.Infraestructure.CrossCutting.Mappers;

//namespace MikeCars.Tests.Mappers.Models;

//public class PessoaJuridicaModelTests
//{
//    private readonly IMapper _mapper;
//    private string CpfValidoUserSecret { get; }

//    public PessoaJuridicaModelTests()
//    {
//        _mapper = new AutoMapperProfileBuilder().Build();
//        CpfValidoUserSecret = UserSecretsBuilder<DocumentoModelTests>.Build();
//    }

//    [Fact]
//    public void RetornaSucessoPessoaJuridicaModel()
//    {
//        PessoaJuridica entity = new(CpfValidoUserSecret, "44436599000186", EnumTipoAgente.Fornecedor)
//        {
//            Abertura = new(2021, 10, 10),
//            RazaoSocial = "MR",
//            NomeFantasia = "MR",
//            ContatoInfo = new()
//            {
//                Email = "mikerozendo@gmail.com",
//                TelefoneCelular = "11949126483",
//            },
//            Endereco = new(EnumTipoEndereco.Comercial, EnumUf.SP)
//            {
//                Logradouro = "Rua",
//                Bairro = "Campo Limpo",
//                Cidade = "São Paulo",
//                Numero = "123 BL A"
//            },
//            Representante = new(CpfValidoUserSecret)
//            {
//                ContatoInfo = new()
//                {
//                    Email = "mikerozendo@gmail.com",
//                    TelefoneCelular = "11949126483",
//                },
//                Endereco = new(EnumTipoEndereco.Residencial, EnumUf.SP)
//                {
//                    Logradouro = "Rua",
//                    Bairro = "Campo Limpo",
//                    Cidade = "São Paulo",
//                    Numero = "123 BL A"
//                },
//                Nascimento = new(1998, 03, 11)
//            },
//        };

//        entity.Documento.Builder();
//        entity.Representante.Documento.Builder();

//        PessoaJuridicaModel model = _mapper.Map<PessoaJuridicaModel>(entity);

//        Assert.Equal(new(2021, 10, 10), model.Abertura);
//        Assert.Equal("44436599000186", model.Documento.Numero);
//        Assert.Equal("MR", model.RazaoSocial);
//        Assert.Equal("MR", model.RazaoSocial);
//        Assert.Equal("mikerozendo@gmail.com", model.ContatoInfo.Email);
//        Assert.Equal("11949126483", model.ContatoInfo.TelefoneCelular);
//        Assert.True(string.IsNullOrEmpty(model.ContatoInfo.TelefoneResidencial));
//        Assert.Equal("Rua", model.Endereco.Logradouro);
//        Assert.Equal("Campo Limpo", model.Endereco.Bairro);
//        Assert.Equal("São Paulo", model.Endereco.Cidade);
//        Assert.Equal("123 BL A", model.Endereco.Numero);
//        Assert.Equal(2, model.Endereco.IdTipoEndereco);
//        Assert.Equal(EnumUf.SP.ToString(), model.Endereco.Uf);
//        Assert.Equal(CpfValidoUserSecret, model.Representante.Documento.Numero);
//        Assert.Equal("mikerozendo@gmail.com", model.Representante.ContatoInfo.Email);
//        Assert.Equal("11949126483", model.Representante.ContatoInfo.TelefoneCelular);
//        Assert.True(string.IsNullOrEmpty(model.Representante.ContatoInfo.TelefoneResidencial));
//        Assert.Equal("Rua", model.Representante.Endereco.Logradouro);
//        Assert.Equal("Campo Limpo", model.Representante.Endereco.Bairro);
//        Assert.Equal("São Paulo", model.Representante.Endereco.Cidade);
//        Assert.Equal("123 BL A", model.Representante.Endereco.Numero);
//        Assert.Equal(1, model.Representante.Endereco.IdTipoEndereco);
//        Assert.Equal(EnumUf.SP.ToString(), model.Representante.Endereco.Uf);
//        Assert.Equal(new(1998, 03, 11), model.Representante.Nascimento);
//    }

//    [Fact]
//    public void RetornaSucessoPessoaJuridica()
//    {
//        PessoaJuridicaModel model = new()
//        {
//            Abertura = new(2021, 10, 10),
//            RazaoSocial = "MR",
//            NomeFantasia = "MR",
//            IdTipoAgente = (int)EnumTipoAgente.Fornecedor,
//            Documento = new DocumentoModel()
//            {
//                Id = 10,
//                Numero = "44436599000186",
//                IdTipoDocumento = (int)EnumTipoDocumento.CNPJ,
//            },
//            ContatoInfo = new()
//            {
//                Email = "mikerozendo@gmail.com",
//                TelefoneCelular = "11949126483",
//            },
//            Endereco = new()
//            {
//                Id = 2,
//                IdTipoEndereco = 2, //comercial
//                Uf = EnumUf.SP.ToString(),
//                Logradouro = "Rua",
//                Bairro = "Campo Limpo",
//                Cidade = "São Paulo",
//                Numero = "123 BL A"
//            },
//            Representante = new PessoaFisicaModel()
//            {
//                Nascimento = new(1998, 03, 11),
//                Nome = "Michael Rozendo",
//                IdTipoAgente = (int)EnumTipoAgente.Representante, //3
//                ContatoInfo = new()
//                {
//                    Email = "mikerozendo@gmail.com",
//                    TelefoneCelular = "11949126483",
//                },
//                Endereco = new()
//                {
//                    Id = 6,
//                    IdTipoEndereco = 1,
//                    Logradouro = "Rua",
//                    Bairro = "Campo Limpo",
//                    Cidade = "São Paulo",
//                    Numero = "123 BL A",
//                    Uf = "SP"
//                },
//                Documento = new DocumentoModel()
//                {
//                    IdTipoDocumento = 1,
//                    Id = 7,
//                    Numero = CpfValidoUserSecret
//                },
//            },
//        };

//        PessoaJuridica entity = _mapper.Map<PessoaJuridica>(model);

//        Assert.Equal(new(2021, 10, 10), entity.Abertura);
//        Assert.Equal("44436599000186", entity.Documento.Numero);
//        Assert.Equal("MR", entity.RazaoSocial);
//        Assert.Equal("MR", entity.RazaoSocial);
//        Assert.Equal("mikerozendo@gmail.com", entity.ContatoInfo.Email);
//        Assert.Equal("11949126483", entity.ContatoInfo.TelefoneCelular);
//        Assert.True(string.IsNullOrEmpty(entity.ContatoInfo.TelefoneResidencial));
//        Assert.Equal("Rua", entity.Endereco.Logradouro);
//        Assert.Equal("Campo Limpo", entity.Endereco.Bairro);
//        Assert.Equal("São Paulo", entity.Endereco.Cidade);
//        Assert.Equal("123 BL A", entity.Endereco.Numero);
//        Assert.Equal(EnumTipoEndereco.Comercial, entity.Endereco.EnumTipoEndereco);
//        Assert.Equal(EnumUf.SP.ToString(), entity.Endereco.EnumUf.ToString());
//        Assert.Equal(CpfValidoUserSecret, entity.Representante.Documento.Numero);
//        Assert.Equal("mikerozendo@gmail.com", entity.Representante.ContatoInfo.Email);
//        Assert.Equal("11949126483", entity.Representante.ContatoInfo.TelefoneCelular);
//        Assert.True(string.IsNullOrEmpty(entity.Representante.ContatoInfo.TelefoneResidencial));
//        Assert.Equal("Rua", entity.Representante.Endereco.Logradouro);
//        Assert.Equal("Campo Limpo", entity.Representante.Endereco.Bairro);
//        Assert.Equal("São Paulo", entity.Representante.Endereco.Cidade);
//        Assert.Equal("123 BL A", entity.Representante.Endereco.Numero);
//        Assert.Equal(EnumTipoEndereco.Residencial, entity.Representante.Endereco.EnumTipoEndereco);
//        Assert.Equal(EnumUf.SP, entity.Representante.Endereco.EnumUf);
//        Assert.Equal(new(1998, 03, 11), entity.Representante.Nascimento);
//    }
//}
