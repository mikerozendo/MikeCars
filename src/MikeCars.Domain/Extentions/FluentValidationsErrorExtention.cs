using FluentResults;

namespace MikeCars.Domain.Extentions;

public static class FluentValidationsErrorExtention
{
    public static string GetErrorMessage(this Result<int> result)
    {
        return result.Errors.Count > 0 ? result.Errors.First().Message : "";
    }
}
