using FluentResults;
using MikeCars.Domain.Entities;

namespace MikeCars.Domain.Interfaces.Services;

public interface IFuncionarioService
{
    Task<Result> Create(Funcionario employee);
    Task<Result> Get();
}
