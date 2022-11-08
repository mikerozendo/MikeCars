using MikeCars.Domain.Entities;

namespace MikeCars.Domain.Interfaces.Repositories.Generic;

public interface IExistsRepository<T> where T : Base
{
    Task<bool> AlreadyExistsAsync(T entity); 
}
