using AutoMapper;
using MikeCars.Dto.Repository.Models;
using MikeCars.Infraestructure.CrossCutting.Mappers;

namespace MikeCars.Tests.Mappers.Models;

public class ContatoInfoModelTestes
{
    private readonly IMapper _mapper;

    public ContatoInfoModelTestes()
    {
        _mapper = new AutoMapperProfileBuilder().Build();
    }

    [Fact]
    public void ReturnaSucessoContatoInfoModel()
    {
        ContatoInfoModel model = new()
        {
            Id = 1,
            TelefoneCelular = "11 9 4912-6483"
        };

        ContatoInfo entity = _mapper.Map<ContatoInfo>(model);

        Assert.Equal(1, entity.Id);
        Assert.Equal("11 9 4912-6483", entity.TelefoneCelular);
        Assert.True(string.IsNullOrEmpty(entity.TelefoneResidencial));
    }


    [Fact]
    public void ReturnaSucessoContatoInfo()
    {
        ContatoInfo entity = new()
        {
            Id = 1,
            TelefoneCelular = "11 9 4912-6483"
        };

        ContatoInfoModel model = _mapper.Map<ContatoInfoModel>(entity);

        Assert.Equal(1, model.Id);
        Assert.Equal("11 9 4912-6483", model.TelefoneCelular);
        Assert.True(string.IsNullOrEmpty(model.TelefoneResidencial));
    }
}
