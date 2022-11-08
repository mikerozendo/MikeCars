namespace MikeCars.Tests.Domain.ValueObjects;

public class CpfValidatorTests
{
    private string _cpfValidoUserSecret { get; }

    public CpfValidatorTests()
    {
        _cpfValidoUserSecret = UserSecretsBuilder<CpfValidatorTests>.Build();
    }


    [Fact]
    public void ValidaCpfValido()
    {
        CpfValidator validator = new(_cpfValidoUserSecret);

        Result result = validator.Build();

        Assert.True(result.IsSuccess);
        Assert.False(validator.CaracteresIguais);
        Assert.True(validator.TamanhoValido);
    }

    [Fact]
    public void ValidaCpfInvalido()
    {
        CpfValidator validator = new("42872357821");

        Result result = validator.Build();

        Assert.False(result.IsSuccess);
        Assert.False(validator.CaracteresIguais);
        Assert.True(validator.TamanhoValido);
    }
}
