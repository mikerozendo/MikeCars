//namespace MikeCars.Tests.Domain.Services;

//public class PessoaServiceTests
//{
//    private readonly Mock<IDocumentoRepository> _documentoRepository;
//    private readonly Mock<IPessoaFisicaRepository> _pessoaRepository;
//    private readonly Mock<IPessoaJuridicaRepository> _pessoaJuridicaRepository;

//    private string CpfValidoUserSecret { get; }

//    public PessoaServiceTests()
//    {
//        _documentoRepository = new Mock<IDocumentoRepository>();
//        _pessoaRepository = new Mock<IPessoaFisicaRepository>();
//        _pessoaJuridicaRepository = new Mock<IPessoaJuridicaRepository>();
//        CpfValidoUserSecret = UserSecretsBuilder<PessoaServiceTests>.Build();
//    }

//    [Fact]
//    public async Task TestaInsertPessoaSucesso()
//    {
//        //Arrange
//        _documentoRepository.Setup(x => x.AlreadyExistsAsync(It.IsAny<Documento>())).ReturnsAsync(false);
//        _pessoaRepository.Setup(x => x.CreateAsync(It.IsAny<PessoaFisica>())).ReturnsAsync(Result.Ok(25));

//        var pessoaService = new PessoaFisicaService(_documentoRepository.Object, _pessoaRepository.Object);
//        PessoaFisica pessoa = ObterPessoaMockSucesso();

//        //Act
//        var response = await pessoaService.CreateAsync(pessoa);

//        //Assert
//        Assert.True(response.IsSuccess);
//        Assert.Equal(25, response.Value);
//    }

//    [Fact]
//    public async Task RetornaErroDocumentoInvalido()
//    {
//        //Arrange
//        _documentoRepository.Setup(x => x.AlreadyExistsAsync(It.IsAny<Documento>())).ReturnsAsync(false);
//        _pessoaRepository.Setup(x => x.CreateAsync(It.IsAny<PessoaFisica>())).ReturnsAsync(It.IsAny<int>());

//        var pessoaService = new PessoaFisicaService(_documentoRepository.Object, _pessoaRepository.Object);
//        PessoaFisica pessoa = ObterPessoaMockErro();

//        //Act
//        var response = await pessoaService.CreateAsync(pessoa);

//        //Assert
//        Assert.True(response.IsFailed);
//        Assert.Equal(0, response.ValueOrDefault);
//        Assert.Equal("Informe um documento valido.", response.GetErrorMessage());
//    }

//    [Fact]
//    public async Task RetornaErroPessoaExistenteNaBase()
//    {
//        //Arrange
//        _documentoRepository.Setup(x => x.AlreadyExistsAsync(It.IsAny<Documento>())).ReturnsAsync(true);
//        _pessoaRepository.Setup(x => x.CreateAsync(It.IsAny<PessoaFisica>())).ReturnsAsync(It.IsAny<int>());

//        var pessoaService = new PessoaFisicaService(_documentoRepository.Object, _pessoaRepository.Object);
//        PessoaFisica pessoa = ObterPessoaMockSucesso();

//        //Act
//        var response = await pessoaService.CreateAsync(pessoa);

//        //Assert
//        Assert.True(response.IsFailed);
//        Assert.Equal(0, response.ValueOrDefault);
//        Assert.Equal("Documento já cadastrado na base", response.GetErrorMessage());
//    }

//    private PessoaFisica ObterPessoaMockErro()
//    {
//        return new(EnumTipoAgente.Representante, "")
//        {
//            Nome = "Michael",
//            Sobrenome = "Rozendo",
//            ContatoInfo = new()
//            {
//                Email = "mikerozendo@gmail.com",
//                TelefoneCelular = "11 9 4912-6483"
//            },
//            Endereco = new(EnumTipoEndereco.Residencial, EnumUf.SP)
//            {
//                Logradouro = "Rua",
//                Bairro = "Campo Limpo",
//                Cidade = "São Paulo",
//                Numero = "123 BL A"
//            }
//        };
//    }

//    private PessoaFisica ObterPessoaMockSucesso()
//    {
//        return new(EnumTipoAgente.Representante, CpfValidoUserSecret)
//        {
//            Nome = "Michael",
//            Sobrenome = "Rozendo",
//            ContatoInfo = new()
//            {
//                Email = "mikerozendo@gmail.com",
//                TelefoneCelular = "11 9 4912-6483"
//            },
//            Endereco = new(EnumTipoEndereco.Residencial, EnumUf.SP)
//            {
//                Logradouro = "Rua",
//                Bairro = "Campo Limpo",
//                Cidade = "São Paulo",
//                Numero = "123 BL A"
//            }
//        };
//    }
//}
