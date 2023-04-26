using MikeCars.Domain.Entities;

namespace MikeCars.Domain.Interfaces.Repositories;

public interface IFuncionarioRepository
{
    Task<int> Create(Funcionario funcionario);
}
