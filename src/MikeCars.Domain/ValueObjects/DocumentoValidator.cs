using FluentResults;
namespace MikeCars.Domain.ValueObjects;

public abstract class DocumentoValidator
{
    protected string DocumentoFormatado { get; private set; }
    public int QuantidadeCaracteres { get; private set; }
    public bool CaracteresIguais { get; private set; }
    public bool TamanhoValido { get; private set; }
    public int QuantidadeValidaCaracteres { get; protected set; }

    public DocumentoValidator(string documentoFormatado)
    {
        DocumentoFormatado = documentoFormatado;
    }

    protected bool InitialBuild()
    {
        DefiniQuantidadeCaracteres();
        ValidaQuantidadeCaracteres();
        DefiniCaracteresIguais();

        return TamanhoValido && !CaracteresIguais;
    }

    protected void ValidaQuantidadeCaracteres()
    {
        TamanhoValido = QuantidadeCaracteres == QuantidadeValidaCaracteres;
    }

    private void DefiniCaracteresIguais()
    {
        var array = DocumentoFormatado.ToCharArray();
        string firstItem = array[0].ToString();
        bool allEqual = array.Skip(1).All(s => string.Equals(firstItem, s.ToString(), StringComparison.InvariantCultureIgnoreCase));
        CaracteresIguais = allEqual;
    }

    private void DefiniQuantidadeCaracteres()
    {
        QuantidadeCaracteres = DocumentoFormatado.Length;
    }

    protected abstract bool CalculaDV();
    public abstract Result Build();
}
