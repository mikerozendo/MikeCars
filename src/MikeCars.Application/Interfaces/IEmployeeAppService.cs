using Microsoft.AspNetCore.Mvc;
using MikeCars.Application.ViewModels;

namespace MikeCars.Application.Interfaces;

public interface IEmployeeAppService
{
    Task<IActionResult> Create(EmployeeViewModel employeeViewModel);
}
