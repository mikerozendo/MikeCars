using MikeCars.Domain.Enums;
using MikeCars.Domain.Entities;

namespace MikeCars.Domain.ValueObjects;

public class Documento : Base
{
    public EnumTipoDocumento EnumTipoDocumento { get; private set; }
    public string Numero { get; private set; }
    public string NumeroFormatado { get; private set; }
    public bool Valido { get; private set; }
    private Dictionary<EnumTipoDocumento, DocumentoValidator> Validators { get; set; } = new();

    public Documento(EnumTipoDocumento enumTipoDocumento, string numero)
    {
        EnumTipoDocumento = enumTipoDocumento;
        Numero = numero;
        Valido = false;
    }

    public Documento(int id) 
    {
        Id = id;
        Valido = true;
    }

    public void Builder()
    {
        if (!string.IsNullOrEmpty(Numero))
        {
            BuildFormatter();
            BuildDictionary();
            BuildValidator();
        }
    }

    private void BuildDictionary()
    {
        Validators.Add(EnumTipoDocumento.CPF, (DocumentoValidator)new CpfValidator(NumeroFormatado));
        Validators.Add(EnumTipoDocumento.CNPJ, (DocumentoValidator)new CnpjValidator(NumeroFormatado));
    }

    private void BuildValidator()
    {
        var toBeInvoked = Validators.FirstOrDefault(x => x.Key.Equals(EnumTipoDocumento)).Value;

        if (toBeInvoked is not null)
        {
            Valido = toBeInvoked.Build().IsSuccess;
        }
    }

    private void BuildFormatter()
    {
        DocumentoFormatter formato = new DocumentoFormatter(Numero).Formata();
        NumeroFormatado = formato.NumeroFormatado;
    }
}
