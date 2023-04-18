namespace MikeCars.Infraestructure.Repository.Models;

public class DepartamentoEmpresaModel : BaseModel
{
    public string Nome { get; set; }
    public int IdDepartamentoEmpresa { get; set; }
    public IEnumerable<FuncionarioModel> Funcionarios { get; set; } = new List<FuncionarioModel>();
}
