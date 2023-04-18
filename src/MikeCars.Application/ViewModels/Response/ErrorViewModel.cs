namespace MikeCars.Application.ViewModels.Response;

public class ErrorViewModel : BaseResponseViewModel
{
    public string ErrorReason { get; set; }
    public ErrorViewModel() 
        : base(Enums.EnumHttpStatus.BadRequest)
    {
    }
}
