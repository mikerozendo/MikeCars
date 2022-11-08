using MikeCars.Domain.Entities;
using FluentResults;

namespace MikeCars.Domain.Interfaces.Repositories.Generic;

public interface ICreateRepository<T> where T : Base
{
    Task<Result<int>> CreateAsync(T entity);
}
