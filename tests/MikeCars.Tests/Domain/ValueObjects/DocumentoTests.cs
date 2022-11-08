namespace MikeCars.Tests.Domain.ValueObjects;

public class DocumentoTests
{
    private string _cpfValidoUserSecret { get; }

    public DocumentoTests()
    {
        _cpfValidoUserSecret = UserSecretsBuilder<DocumentoTests>.Build();
    }

    [Fact]
    public void TestaCpfValido()
    {
        Documento documento = new Documento(EnumTipoDocumento.CPF, _cpfValidoUserSecret);

        documento.Builder();

        Assert.True(documento.Valido);
    }

    [Fact]
    public void TestaCpfInvalido()
    {
        Documento documento = new Documento(EnumTipoDocumento.CPF, "338.322.598-12");

        documento.Builder();

        Assert.False(documento.Valido);
    }

    [Fact]
    public void TestaCpfInvalidoVazio()
    {
        Documento documento = new Documento(EnumTipoDocumento.CPF, "");

        documento.Builder();

        Assert.False(documento.Valido);
    }

    [Fact]
    public void TestaCnpjInvalidoVazio()
    {
        Documento documento = new Documento(EnumTipoDocumento.CNPJ, "");

        documento.Builder();

        Assert.False(documento.Valido);
    }
}
