using FluentResults;
using MikeCars.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeCars.Domain.Interfaces.Services;

public interface IEmployeeService
{
    Task<Result> Create(EmployeeViewModel)
}
