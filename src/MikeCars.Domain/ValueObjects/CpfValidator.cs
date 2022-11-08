using FluentResults;

namespace MikeCars.Domain.ValueObjects;

public class CpfValidator : DocumentoValidator
{
    public CpfValidator(string documentoFormatado) : base(documentoFormatado)
    {
        QuantidadeValidaCaracteres = 11;
    }

    public override Result Build()
    {
        if (InitialBuild())
            return Result.OkIf(CalculaDV(), () => new("Informa um documento válido"));

        return Result.Fail("Informa um documento válido");
    }

    protected sealed override bool CalculaDV()
    {
        char[] cpfBase = DocumentoFormatado.ToCharArray();

        int primeiroDV, segundoDV, somaDv = 0;
        int multiplicador = 10;

        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        try
        {
            for (int i = 0; i < cpfBase.Count() - 2; i++)
            {
                dictionary.Add(i, multiplicador * int.Parse(cpfBase[i].ToString()));
                if (dictionary.TryGetValue(i, out int value))
                {
                    somaDv += value;
                }
                multiplicador -= 1;
            }

            primeiroDV = 11 - (somaDv % 11);
            multiplicador = 11;
            dictionary.Clear();
            somaDv = 0;

            if (primeiroDV.ToString() == cpfBase[9].ToString() ||
                (primeiroDV == 0 && cpfBase[9] == '0') ||
                (primeiroDV == 1 && cpfBase[9] == '0'))
            {
                for (int i = 0; i < cpfBase.Count() - 1; i++)
                {
                    dictionary.Add(i, multiplicador * int.Parse(cpfBase[i].ToString()));

                    if (dictionary.TryGetValue(i, out int value))
                        somaDv += value;

                    multiplicador -= 1;
                }
                segundoDV = 11 - (somaDv % 11);

                return segundoDV.ToString() == cpfBase[10].ToString() ||
                segundoDV == 0 && cpfBase[10] == '0' ||
                segundoDV == 1 && cpfBase[10] == '0';
            }
            else return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
