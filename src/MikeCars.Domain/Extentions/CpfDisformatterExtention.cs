using System.Text;

namespace MikeCars.Domain.Extentions;

public static class CpfDisformatterExtention
{
    public static string GetCpfUnformattedValue(this string cpfFormatted)
    {
        var values = cpfFormatted.ToCharArray();

        StringBuilder sb = new();

        sb.Append(String.Concat(values[0], values[1], values[2], "."));
        sb.Append(String.Concat(values[3], values[4], values[5], "."));
        sb.Append(String.Concat(values[6], values[7], values[8], "."));
        sb.Append(String.Concat("-", values[9], values[10]));

        return sb.ToString();
    }
}
