//using AutoMapper;
//using MikeCars.Infraestructure.Repository.Models;
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
//        PessoaJuridica entity = new("44436599000186", EnumTipoAgente.Fornecedor)
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
//        Assert.Equal("44436599000186", model.DocumentoModel.Numero);
//        Assert.Equal("MR", model.RazaoSocial);
//        Assert.Equal("MR", model.RazaoSocial);
//        Assert.Equal("mikerozendo@gmail.com", model.ContatoInfoModel.Email);
//        Assert.Equal("11949126483", model.ContatoInfoModel.TelefoneCelular);
//        Assert.True(string.IsNullOrEmpty(model.ContatoInfoModel.TelefoneResidencial));
//        Assert.Equal("Rua", model.EnderecoModel.Logradouro);
//        Assert.Equal("Campo Limpo", model.EnderecoModel.Bairro);
//        Assert.Equal("São Paulo", model.EnderecoModel.Cidade);
//        Assert.Equal("123 BL A", model.EnderecoModel.Numero);
//        Assert.Equal(2, model.EnderecoModel.IdTipoEndereco);
//        Assert.Equal(EnumUf.SP.ToString(), model.EnderecoModel.Uf);
//        Assert.Equal(CpfValidoUserSecret, model.RepresentanteModel.PessoaFisicaModel.DocumentoModel.Numero);
//        Assert.Equal("mikerozendo@gmail.com", model.RepresentanteModel.PessoaFisicaModel.ContatoInfoModel.Email);
//        Assert.Equal("11949126483", model.RepresentanteModel.PessoaFisicaModel.ContatoInfoModel.TelefoneCelular);
//        Assert.True(string.IsNullOrEmpty(model.RepresentanteModel.PessoaFisicaModel.ContatoInfoModel.TelefoneResidencial));
//        Assert.Equal("Rua", model.RepresentanteModel.PessoaFisicaModel.EnderecoModel.Logradouro);
//        Assert.Equal("Campo Limpo", model.RepresentanteModel.PessoaFisicaModel.EnderecoModel.Bairro);
//        Assert.Equal("São Paulo", model.RepresentanteModel.PessoaFisicaModel.EnderecoModel.Cidade);
//        Assert.Equal("123 BL A", model.RepresentanteModel.PessoaFisicaModel.EnderecoModel.Numero);
//        Assert.Equal(1, model.RepresentanteModel.PessoaFisicaModel.EnderecoModel.IdTipoEndereco);
//        Assert.Equal(EnumUf.SP.ToString(), model.RepresentanteModel.PessoaFisicaModel.EnderecoModel.Uf);
//        Assert.Equal(new(1998, 03, 11), model.RepresentanteModel.PessoaFisicaModel.Nascimento);
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
//            ContatoInfoModel = new()
//            {
//                Email = "mikerozendo@gmail.com",
//                TelefoneCelular = "11949126483",
//            },
//            EnderecoModel = new()
//            {
//                Id = 2,
//                IdTipoEndereco = 2, //comercial
//                Uf = EnumUf.SP.ToString(),
//                Logradouro = "Rua",
//                Bairro = "Campo Limpo",
//                Cidade = "São Paulo",
//                Numero = "123 BL A"
//            },
//            DocumentoModel = new DocumentoModel()
//            {
//                Id = 10,
//                Numero = "44436599000186",
//                IdTipoDocumento = (int)EnumTipoDocumento.CNPJ,
//            },
//            RepresentanteModel = new RepresentanteModel()
//            {
//                PessoaFisicaModel = new()
//                {
//                    Nascimento = new(1998, 03, 11),
//                    Nome = "Michael Rozendo",
//                    IdTipoAgente = (int)EnumTipoAgente.Representante, //3
//                    ContatoInfoModel = new()
//                    {
//                        Email = "mikerozendo@gmail.com",
//                        TelefoneCelular = "11949126483",
//                    },
//                    EnderecoModel = new()
//                    {
//                        Id = 6,
//                        IdTipoEndereco = 1,
//                        Logradouro = "Rua",
//                        Bairro = "Campo Limpo",
//                        Cidade = "São Paulo",
//                        Numero = "123 BL A",
//                        Uf = "SP"
//                    },
//                    DocumentoModel = new DocumentoModel()
//                    {
//                        IdTipoDocumento = 1,
//                        Id = 7,
//                        Numero = CpfValidoUserSecret
//                    },
//                }
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
