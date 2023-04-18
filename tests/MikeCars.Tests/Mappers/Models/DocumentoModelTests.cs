using AutoMapper;
using MikeCars.Dto.Models;
using MikeCars.Infraestructure.CrossCutting.Mappers;

namespace MikeCars.Tests.Mappers.Models;

public class DocumentoModelTests
{
    private readonly IMapper _mapper;
    private string CpfValidoUserSecret { get; }

    public DocumentoModelTests()
    {
        _mapper = new AutoMapperProfileBuilder().Build();
        CpfValidoUserSecret = UserSecretsBuilder<DocumentoModelTests>.Build();
    }

    [Fact]
    public void RetornaSucessoConfiguracaoAutoMapperValida()
    {
        var configuration = new AutoMapperProfileBuilder().CreateAutoMapperConfiguration();
        configuration.AssertConfigurationIsValid();
    }

    [Fact]
    public void ReturnaSucessoDocumento()
    {
        DocumentoModel model = new()
        {
            Id = 1,
            IdTipoDocumento = 1,
            Numero = CpfValidoUserSecret
        };

        Documento entity = _mapper.Map<Documento>(model);

        Assert.Equal(EnumTipoDocumento.CPF, entity.EnumTipoDocumento);
        Assert.Equal(CpfValidoUserSecret, entity.Numero);
        Assert.Equal(CpfValidoUserSecret, entity.NumeroFormatado);
        Assert.True(entity.Valido);
    }

    [Fact]
    public void ReturnaSucessoDocumentoModel()
    {
        Documento entity = new(EnumTipoDocumento.CPF, "333333333");

        entity.Builder();

        DocumentoModel model = _mapper.Map<DocumentoModel>(entity);

        Assert.Equal((int)EnumTipoDocumento.CPF, model.IdTipoDocumento);
        Assert.Equal("333333333", model.Numero);
    }
}
