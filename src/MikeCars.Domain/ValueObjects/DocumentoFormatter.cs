namespace MikeCars.Domain.ValueObjects;

public class DocumentoFormatter
{
    public string NumeroFormatado { get; set; }
    public string NumeroSemFormatacao { get; set; }
    public bool Valido { get; private set; }

    public DocumentoFormatter(string numero)
    {
        NumeroSemFormatacao = numero;
        Valido = false;
    }

    protected void DefiniFormatoValido()
    {
        Valido = true;
    }

    public DocumentoFormatter Formata()
    {
        string documentoHelper = "";
        documentoHelper = NumeroSemFormatacao.Replace(".", "");
        documentoHelper = documentoHelper.Replace("-", "");
        documentoHelper = documentoHelper.Replace("/", "");

        NumeroFormatado = documentoHelper;
        DefiniFormatoValido();
        return this;
    }
}
