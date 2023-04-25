using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public class DepartamentoEmpresa : Base
{
    public string Nome { get; private set; }
    public EnumDepartamentoEmpresa EnumDepartamentoEmpresa { get; set; }
    public IEnumerable<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public DepartamentoEmpresa(EnumDepartamentoEmpresa enumDepartamentoEmpresa)
    {
        EnumDepartamentoEmpresa = enumDepartamentoEmpresa;
        Nome = EnumDepartamentoEmpresa.ToString();
    }

    public List<Funcionario> GetActiveEmploes()
    {
        return Funcionarios.ToList().Where(x => x.Ativo).ToList();
    }
}
