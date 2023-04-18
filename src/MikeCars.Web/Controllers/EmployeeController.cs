using Microsoft.AspNetCore.Mvc;
using MikeCars.Application.ViewModels;

namespace MikeCars.Web.Controllers;

public class EmployeeController : Controller
{
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeViewModel employee)
    {
        await Task.Delay(12);
        return View();
    }
}
