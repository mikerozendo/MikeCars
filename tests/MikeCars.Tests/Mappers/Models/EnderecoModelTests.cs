using AutoMapper;
using MikeCars.Dto.Models;
using MikeCars.Infraestructure.CrossCutting.Mappers;

namespace MikeCars.Tests.Mappers.Models;

public class EnderecoModelTests
{
    private readonly IMapper _mapper;

    public EnderecoModelTests()
    {
        _mapper = new AutoMapperProfileBuilder().Build();
    }

    [Fact]
    public void RetornaSucessoEndereco()
    {
        EnderecoModel model = new()
        {
            Logradouro = "Rua",
            Bairro = "Campo Limpo",
            Cidade = "São Paulo",
            Numero = "123 BL A",
            Id = 1,
            IdTipoEndereco = 1,
            Uf = "SP",
            PontoReferencia = "Não importa"
        };

        Endereco entity = _mapper.Map<Endereco>(model);

        Assert.Equal(EnumTipoEndereco.Residencial, entity.EnumTipoEndereco);
        Assert.Equal(1, entity.Id);
        Assert.Equal("Rua", entity.Logradouro);
        Assert.Equal("São Paulo", entity.Cidade);
        Assert.Equal("Campo Limpo", entity.Bairro);
        Assert.Equal("123 BL A", entity.Numero);
        Assert.Equal(EnumUf.SP, entity.EnumUf);
        Assert.Equal("Não importa", entity.PontoReferencia);
    }

    [Fact]
    public void RetornaSucessoEnderecoModel()
    {
        Endereco entity = new(EnumTipoEndereco.Residencial, EnumUf.SP)
        {
            Logradouro = "Rua",
            Bairro = "Campo Limpo",
            Cidade = "São Paulo",
            Numero = "123 BL A"
        };

        EnderecoModel model = _mapper.Map<EnderecoModel>(entity);

        Assert.Equal((int)EnumTipoEndereco.Residencial, model.IdTipoEndereco);
        Assert.Equal("Rua", model.Logradouro);
        Assert.Equal("São Paulo", model.Cidade);
        Assert.Equal("123 BL A", model.Numero);
        Assert.Equal(EnumUf.SP.ToString(), model.Uf);
    }
}
