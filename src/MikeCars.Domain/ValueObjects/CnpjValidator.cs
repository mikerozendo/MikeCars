using FluentResults;

namespace MikeCars.Domain.ValueObjects;

public sealed class CnpjValidator : DocumentoValidator
{
    public CnpjValidator(string documentoFormatado) : base(documentoFormatado)
    {
        QuantidadeValidaCaracteres = 14;
    }

    public override Result Build()
    {
        if (InitialBuild())
            return Result.OkIf(CalculaDV(), () => new("Informa um documento válido"));

        return Result.Fail("Informa um documento válido");
    }

    protected sealed override bool CalculaDV()
    {
        char[] cnpjCarcteres = DocumentoFormatado.ToCharArray();

        int primeiroDV, segundoDV, somaDv = 0;
        int multiplicador = 6;
        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        try
        {
            for (int i = 0; i <= cnpjCarcteres.Count() - 3; i++)
            {
                if (multiplicador > 9)
                    multiplicador = 2;

                dictionary.Add(i, multiplicador * int.Parse(cnpjCarcteres[i].ToString()));

                if (dictionary.TryGetValue(i, out int value))
                    somaDv += value;

                multiplicador++;
            }

            multiplicador = 5;
            primeiroDV = somaDv % 11;
            dictionary.Clear();

            if (primeiroDV.ToString() == cnpjCarcteres[12].ToString())
            {
                for (int i = 0; i <= cnpjCarcteres.Count() - 2; i++)
                {
                    if (multiplicador > 9)
                        multiplicador = 2;

                    dictionary.Add(i, multiplicador * int.Parse(cnpjCarcteres[i].ToString()));

                    if (dictionary.TryGetValue(i, out int value) && i == 0)
                        somaDv = value;
                    else if (dictionary.TryGetValue(i, out int obj))
                        somaDv += obj;

                    multiplicador++;
                }

                segundoDV = somaDv % 11;

                return segundoDV.ToString() == cnpjCarcteres[13].ToString();
            }
            else return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
