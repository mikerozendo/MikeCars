namespace MikeCars.Dto.Repository.Models;

public class PessoaFisicaModel : Base
{
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }
    public AgenteModel AgenteModel { get; set; }
    public int IdAgenteModel { get; set; }
}
