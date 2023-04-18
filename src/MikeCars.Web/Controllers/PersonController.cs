using Microsoft.AspNetCore.Mvc;

namespace MikeCars.Web.Controllers;

public class PersonController : Controller
{
    public IActionResult Create()
    {
        return View();
    }
}
