using MikeCars.Domain.Entities;
using FluentResults;

namespace MikeCars.Domain.Interfaces.Services.Generic;

public interface IPessoaGenericService<T> where T : Agente
{
    Task<Result<int>> CreateAsync(T entity);
}
