namespace MikeCars.Dto.Models;

public class FuncionarioModel : Base
{
    public decimal Salario { get; set; }
    public bool Ativo { get; set; }
    public DateTime Admissao { get; set; }
    public DateTime? Demissao { get; set; } = null;
    public DateTime? UltimasFerias { get; set; } = null;
    public int IdTipoFuncionario { get; private set; }
    public DepartamentoEmpresaModel DepartamentoEmpresa { get; set; }
    public int IdDepartamento { get; set; }
    public AgenteModel AgenteModel { get; set; }
    public int IdAgenteModel { get; set; }
}
