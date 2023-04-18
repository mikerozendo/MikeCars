namespace MikeCars.Application.ViewModels.Response;

public class SuccessWithMultipleElementsViewModel : BaseResponseViewModel
{
    public List<object> Body { get; set; }

    public SuccessWithMultipleElementsViewModel(List<object> list) 
        : base(Enums.EnumHttpStatus.PartialContent)
    {
        Body = list;
    }
}
