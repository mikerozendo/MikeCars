using MikeCars.Application.Interfaces;
using MikeCars.Application.ViewModels;

namespace MikeCars.Application.Services;

public class EmployeeAppService : IEmployeeAppService
{
    public async Task<object> Create(EmployeeViewModel employeeViewModel)
    {
        return string.Empty;
    }
}
