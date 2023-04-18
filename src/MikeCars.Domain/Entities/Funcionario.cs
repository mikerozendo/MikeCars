using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public abstract class Funcionario : PessoaFisica
{
    public decimal Salario { get; set; }
    public DateTime Admissao { get; set; }
    public DateTime? Demissao { get; private set; } = null;
    public EnumTipoFuncionario EnumTipoFuncionario { get; private set; }//talvez nao faça sentido 
    public FeriasSinteticoInfo FeriasSinteticoInfo { get; set; }
    public DepartamentoEmpresa DepartamentoEmpresa { get; private set; }


    public Funcionario(EnumTipoFuncionario enumTipoFuncionario,EnumDepartamentoEmpresa enumDepartamentoEmpresa,string numeroDocumento) 
        : base(EnumTipoAgente.Funcionario, EnumTipoDocumento.CPF, numeroDocumento)
    {
        EnumTipoFuncionario = enumTipoFuncionario;
        DepartamentoEmpresa = new(enumDepartamentoEmpresa);
    }

    public void DefiniFerias()
    {
        FeriasSinteticoInfo = new(this);
    }
}
