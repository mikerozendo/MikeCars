namespace MikeCars.Tests.Domain.ValueObjects;

public class DocumentoFormatterTests
{
    [Theory]
    [InlineData("000.000.000-21")]
    [InlineData("000000000-21")]
    [InlineData("00000000021")]
    public void TestCpfFormatoValido(string cpf)
    {
        DocumentoFormatter documento = new(cpf);

        documento.Formata();

        Assert.True(documento.Valido);
    }

    [Fact]
    public void TestNumeroFormatadoCpf_Case_1()
    {
        DocumentoFormatter documento = new("000.000.000-21");

        documento.Formata();

        Assert.True(documento.Valido);
        Assert.Equal("00000000021", documento.NumeroFormatado);
    }

    [Fact]
    public void TestNumeroFormatadoCpf_Case_2()
    {
        DocumentoFormatter documento = new("000.000000-21");

        documento.Formata();

        Assert.True(documento.Valido);
        Assert.Equal("00000000021", documento.NumeroFormatado);
    }

    [Fact]
    public void TestNumeroFormatadoCpf_Case_3()
    {
        DocumentoFormatter documento = new("000.00000021");

        documento.Formata();

        Assert.True(documento.Valido);
        Assert.Equal("00000000021", documento.NumeroFormatado);
    }
}

