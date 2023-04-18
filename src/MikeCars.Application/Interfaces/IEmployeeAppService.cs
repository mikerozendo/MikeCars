using MikeCars.Application.ViewModels;

namespace MikeCars.Application.Interfaces;

public interface IEmployeeAppService
{
    Task<object> Create(EmployeeViewModel employeeViewModel);
}
