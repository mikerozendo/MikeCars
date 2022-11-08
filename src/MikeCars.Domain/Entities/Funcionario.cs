using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public abstract class Funcionario : PessoaFisica
{
    public decimal Salario { get; set; }
    public int DiasVencimentoProximaFerias { get; private set; }
    public bool FeriasVencida { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime Admissao { get; set; }
    public DateTime? Demissao { get; private set; } = null;
    public DateTime? UltimasFerias { get; set; } = null;
    public DateTime ProximaFerias { get; private set; }
    public EnumTipoFuncionario EnumTipoFuncionario { get; private set; }
    public DepartamentoEmpresa DepartamentoEmpresa { get; private set; }


    public Funcionario(
        EnumTipoFuncionario enumTipoFuncionario,
        EnumDepartamentoEmpresa enumDepartamentoEmpresa,
        string numeroDocumento) : base(EnumTipoAgente.Funcionario, EnumTipoDocumento.CPF, numeroDocumento)
    {
        EnumTipoFuncionario = enumTipoFuncionario;
        DepartamentoEmpresa = new(enumDepartamentoEmpresa);
    }

    public void DefiniProximasFerias()
    {
        ObtemDiferencaDiasUltimasFerias();
        ProximaFerias = DateTime.Now.Date.AddDays(DiasVencimentoProximaFerias);
    }

    public void FeriasVencidas()
    {
        FeriasVencida = DiasVencimentoProximaFerias > 365;
    }

    private void ObtemDiferencaDiasUltimasFerias()
    {
        if (UltimasFerias is null)
        {
            DiasVencimentoProximaFerias = DateTime.Today.Date.Subtract(Admissao.Date).Days;
        }
        else
        {
            DiasVencimentoProximaFerias = UltimasFerias.Value.Date.Subtract(DateTime.Now.Date).Days;
        }
    }
}
