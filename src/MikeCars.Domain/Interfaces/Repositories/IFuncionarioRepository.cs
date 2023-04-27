using MikeCars.Domain.Entities;

namespace MikeCars.Domain.Interfaces.Repositories;

public interface IFuncionarioRepository
{
    Task Create(Funcionario funcionario);
}
