namespace MikeCars.Application.ViewModels.Response;

public class SuccessWithSingleElementViewModel : BaseResponseViewModel
{
    public object Body { get; set; }

    public SuccessWithSingleElementViewModel(object body) 
        : base(Enums.EnumHttpStatus.PartialContent)
    {
        Body = body;
    }
}
