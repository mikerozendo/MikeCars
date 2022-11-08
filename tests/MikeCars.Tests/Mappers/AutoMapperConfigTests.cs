using MikeCars.Infraestructure.CrossCutting.Mappers;

namespace MikeCars.Tests.Mappers.Models;

public class AutoMapperConfigTests
{

    [Fact]
    public void RetornaSucessoConfiguracaoAutoMapperValida()
    {
        var configuration = new AutoMapperProfileBuilder().CreateAutoMapperConfiguration();
        configuration.AssertConfigurationIsValid();
    }
}
