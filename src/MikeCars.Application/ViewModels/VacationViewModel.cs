namespace MikeCars.Application.ViewModels;

public class VacationViewModel
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool Bought { get; set; }
    public bool IsPast { get; set; }
    public int BoughtDaysAmount { get; set; }
    public int DaysSentToEmployee { get; set; }
}
