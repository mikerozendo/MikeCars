using Microsoft.AspNetCore.Mvc;
using MikeCars.Application.Interfaces;
using MikeCars.Application.Mappers;
using MikeCars.Application.ViewModels;
using MikeCars.Domain.Interfaces.Services;

namespace MikeCars.Application.Services;

public class EmployeeAppService : IEmployeeAppService
{
    private readonly IFuncionarioService _employeeService;
    public EmployeeAppService(IFuncionarioService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
    {
        var domainModel = employeeViewModel.ToDomainModel();
        var result = await _employeeService.Create(domainModel);

        if (result.IsSuccess)
        {
            return new OkObjectResult("Success to create a employee in the system!");
        }
        else
        {
            return new BadRequestObjectResult("ERROR when creating a employee in the system!");
        }
    }
}
