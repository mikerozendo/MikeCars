using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public abstract class Operador : Funcionario
{
    public Operador(EnumTipoFuncionario tipoFuncionario, EnumDepartamentoEmpresa departamentoEmpresa, string numeroDocumento)
        : base(tipoFuncionario, departamentoEmpresa, numeroDocumento)
    {        
    }
}
