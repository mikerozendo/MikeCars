//using MikeCars.Domain.Interfaces.Services;

//namespace MikeCars.Tests.Domain.Services;

//public class PessoaJuridicaTests
//{
//    private readonly Mock<IPessoaJuridicaRepository> _pessoaJuridicaRepository;
//    private readonly Mock<IPessoaFisicaService> _pessoaFisicaService;
//    private readonly Mock<IDocumentoRepository> _documentoRepository;
//    private string CpfValidoUserSecret { get; }

//    public PessoaJuridicaTests()
//    {
//        _pessoaJuridicaRepository = new Mock<IPessoaJuridicaRepository>();
//        _pessoaFisicaService = new Mock<IPessoaFisicaService>();
//        _documentoRepository = new Mock<IDocumentoRepository>();
//        CpfValidoUserSecret = UserSecretsBuilder<PessoaJuridicaTests>.Build();
//    }

//    [Fact]
//    public async void TestaInsertSucessoPessoaJurida()
//    {
//        //Arrange
//        _documentoRepository.Setup(x => x.AlreadyExistsAsync(It.IsAny<Documento>())).ReturnsAsync(false);
//        _pessoaFisicaService.Setup(x => x.CreateAsync(It.IsAny<PessoaFisica>())).ReturnsAsync(Result.Ok(25));
//        _pessoaJuridicaRepository.Setup(x => x.CreateAsync(It.IsAny<PessoaJuridica>())).ReturnsAsync(Result.Ok(12));

//        var pessoaService = new PessoaJuridicaService(_documentoRepository.Object, _pessoaJuridicaRepository.Object, _pessoaFisicaService.Object);
//        var pessoaJuridica = ObterPessoaJuridicaMockSucesso();

//        //Act
//        var response = await pessoaService.CreateAsync(pessoaJuridica);

//        //Assert
//        Assert.True(response.IsSuccess);
//        Assert.Equal(12, response.Value);
//    }

//    [Fact]
//    public async void RetornaErroQuandoEmpresaExistente()
//    {
//        //Arrange
//        _documentoRepository.Setup(x => x.AlreadyExistsAsync(It.IsAny<Documento>())).ReturnsAsync(true);
//        _pessoaFisicaService.Setup(x => x.CreateAsync(It.IsAny<PessoaFisica>())).ReturnsAsync(0);
//        _pessoaJuridicaRepository.Setup(x => x.CreateAsync(It.IsAny<PessoaJuridica>())).ReturnsAsync(0);

//        var pessoaService = new PessoaJuridicaService(_documentoRepository.Object, _pessoaJuridicaRepository.Object, _pessoaFisicaService.Object);
//        var pessoaJuridica = ObterPessoaJuridicaMockSucesso();

//        //Act
//        var response = await pessoaService.CreateAsync(pessoaJuridica);

//        //Assert
//        Assert.False(response.IsSuccess);
//        Assert.Equal("Empresa já cadastrada na base", response.GetErrorMessage());
//        Assert.Equal(0, response.ValueOrDefault);
//    }

//    [Fact]
//    public async void RetornaErroCadastroRepresentante()
//    {
//        //Arrange
//        _documentoRepository.Setup(x => x.AlreadyExistsAsync(It.IsAny<Documento>())).ReturnsAsync(false);
//        _pessoaFisicaService.Setup(x => x.CreateAsync(It.IsAny<PessoaFisica>())).ReturnsAsync(Result.Fail<int>(""));
//        _pessoaJuridicaRepository.Setup(x => x.CreateAsync(It.IsAny<PessoaJuridica>())).ReturnsAsync(0);

//        var pessoaService = new PessoaJuridicaService(_documentoRepository.Object, _pessoaJuridicaRepository.Object, _pessoaFisicaService.Object);
//        var pessoaJuridica = ObterPessoaFisicaMockDocumentoInvalido();

//        //Act
//        var response = await pessoaService.CreateAsync(pessoaJuridica);

//        //Assert
//        Assert.False(response.IsSuccess);
//        Assert.Equal(0, response.ValueOrDefault);
//    }

//    private PessoaJuridica ObterPessoaJuridicaMockSucesso()
//    {
//        return new PessoaJuridica(CpfValidoUserSecret, "44436599000186", EnumTipoAgente.Fornecedor)
//        {
//            Abertura = new(2021, 10, 10),
//            RazaoSocial = "MR",
//            NomeFantasia = "MR",
//            ContatoInfo = new()
//            {
//                Email = "mikerozendo@gmail.com",
//                TelefoneCelular = "11949126483",
//            },
//            Endereco = new(EnumTipoEndereco.Residencial, EnumUf.SP)
//            {
//                Logradouro = "Rua",
//                Bairro = "Campo Limpo",
//                Cidade = "São Paulo",
//                Numero = "123 BL A"
//            },
//            Representante = new(CpfValidoUserSecret, 44436599000186"44436599000186", EnumTipoAgente.Fornecedor)
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
//    }

//    private PessoaJuridica ObterPessoaFisicaMockDocumentoInvalido()
//    {
//        return new PessoaJuridica("", "44436599000186", EnumTipoAgente.Fornecedor)
//        {
//            Abertura = new(2021, 10, 10),
//            RazaoSocial = "MR",
//            NomeFantasia = "MR",
//            ContatoInfo = new()
//            {
//                Email = "mikerozendo@gmail.com",
//                TelefoneCelular = "11949126483",
//            },
//            Endereco = new(EnumTipoEndereco.Residencial, EnumUf.SP)
//            {
//                Logradouro = "Rua",
//                Bairro = "Campo Limpo",
//                Cidade = "São Paulo",
//                Numero = "123 BL A"
//            },
//            Representante = new("")
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
//    }

//    //private PessoaFISICA ObterPessoaMockSucesso()
//    //{
//    //    return new(EnumTipoAgente.Representante, CpfValidoUserSecret)
//    //    {
//    //        Nome = "Michael",
//    //        Sobrenome = "Rozendo",
//    //        ContatoInfo = new()
//    //        {
//    //            Email = "mikerozendo@gmail.com",
//    //            TelefoneCelular = "11 9 4912-6483"
//    //        },
//    //        Endereco = new(EnumTipoEndereco.Residencial, EnumUf.SP)
//    //        {
//    //            Logradouro = "Rua",
//    //            Bairro = "Campo Limpo",
//    //            Cidade = "São Paulo",
//    //            Numero = "123 BL A"
//    //        }
//    //    };
//    //}
//}
