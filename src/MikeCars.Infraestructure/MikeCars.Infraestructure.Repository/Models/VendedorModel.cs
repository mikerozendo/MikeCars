namespace MikeCars.Infraestructure.Repository.Models;

public class VendedorModel : BaseModel
{
    public decimal ComissaoPorVenda { get; set; }
    public AgenteModel AgenteModel { get; set; }
    public int IdAgenteModel { get; set; }
    public FuncionarioModel FuncionarioModel { get; set; }
    public int IdFuncionarioModel { get; set; }
}
