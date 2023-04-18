using MikeCars.Application.ViewModels.Response.Enums;

namespace MikeCars.Application.ViewModels.Response;

public class BaseResponseViewModel
{
    private EnumHttpStatus EnumHttpStatus { get; set; }
    public int HttpStatusCode { get; private set; }
    public string HttpStatusDescription { get; private set; }

    public BaseResponseViewModel(EnumHttpStatus enumHttpStatus)
    {
        EnumHttpStatus = enumHttpStatus;
        HttpStatusCode = (int)enumHttpStatus;
        HttpStatusDescription = EnumHttpStatus.ToString();
    }
}
