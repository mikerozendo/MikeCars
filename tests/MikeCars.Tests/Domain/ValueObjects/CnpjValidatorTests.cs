namespace MikeCars.Tests.Domain.ValueObjects;

public class CnpjValidatorTests
{
    [Fact]
    public void ValidaCnpjValido()
    {
        CnpjValidator validator = new("44436599000186");

        Result result = validator.Build();

        Assert.True(result.IsSuccess);
        Assert.False(validator.CaracteresIguais);
        Assert.True(validator.TamanhoValido);
    }

    [Fact]
    public void ValidaCnpjInvalido()
    {
        CnpjValidator validator = new("44436599000188");

        Result result = validator.Build();

        Assert.False(result.IsSuccess);
        Assert.False(validator.CaracteresIguais);
        Assert.True(validator.TamanhoValido);
    }
}
