namespace MikeCars.Dto.Models;

public class VendedorModel : Base
{
    public decimal ComissaoPorVenda { get; set; }
    public AgenteModel AgenteModel { get; set; }
    public int IdAgenteModel { get; set; }
    public FuncionarioModel FuncionarioModel { get; set; }
    public int IdFuncionarioModel { get; set; }
}
