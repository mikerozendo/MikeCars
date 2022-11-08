namespace MikeCars.Dto.Repository.Models;

public class DepartamentoEmpresaModel : Base
{
    public string Nome { get; set; }
    public int IdDepartamentoEmpresa { get; set; }
    public IEnumerable<FuncionarioModel> Funcionarios { get; set; } = new List<FuncionarioModel>();
}
