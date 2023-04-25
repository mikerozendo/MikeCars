using Microsoft.AspNetCore.Mvc;
using MikeCars.Application.Interfaces;
using MikeCars.Application.ViewModels;

namespace MikeCars.Web.Controllers;

public class EmployeeController : Controller
{
    //private readonly IEmployeeAppService _employeeAppService;
    //public EmployeeController(IEmployeeAppService employeeAppService)
    //{
    //    _employeeAppService = employeeAppService;
    //}

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Details(int id)
    {

        #region Mock
        EmployeeViewModel employee = new EmployeeViewModel()
        {
            AdressReferencePoint = "Ao lado do marceneiro",
            BirthDate = new DateTime(1998, 03, 11),
            CellPhone = "11 9 4012-6493",
            City = "Sao Paulo",
            DocumentNumber = "437.724.566-21",
            Email = "ikerozendo@gmailcom",
            FirstName = "Michael",
            LastName = "Rozendo",
            Id = 1,
            Neighborhood = "Parque Regina",
            State = "SP",
            Street = "Rua Padre Justino",
            StreetNumber = "661",
            TypeEmployeeId = 1,
            DepartmentId = 1,
            ContractStartDate = new DateTime(1998, 03, 11),
            ZipCode = "05772060",
            SalaryAmount = 9350,
        };
        #endregion

        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeViewModel employee)
    {
        return Ok();
        //return await _employeeAppService.Create(employee);
    }
}
