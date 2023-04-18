using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using MikeCars.Dto.ViewModels;

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
