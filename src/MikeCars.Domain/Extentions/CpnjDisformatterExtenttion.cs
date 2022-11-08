using System.Text;

namespace MikeCars.Domain.Extentions;

public static class CpnjDisformatterExtenttion
{
    public static string GetCnpjUnformattedValue(this string cnpjFormatted)
    {
        var values = cnpjFormatted.ToCharArray();

        StringBuilder sb = new();

        sb.Append(String.Concat(values[0], values[1], "."));
        sb.Append(String.Concat(values[2], values[3], values[4], "."));
        sb.Append(String.Concat(values[5], values[6], values[7], "/"));
        sb.Append(String.Concat(values[8], values[9], values[11], "-"));
        sb.Append(String.Concat(values[12], values[13]));

        return sb.ToString();
    }
}
