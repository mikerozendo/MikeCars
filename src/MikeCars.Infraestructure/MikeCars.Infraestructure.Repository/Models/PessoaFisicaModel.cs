namespace MikeCars.Infraestructure.Repository.Models;

public class PessoaFisicaModel
{
    public int PessoaFisicaModelId { get; set; }
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }
    public AgenteModel AgenteModel { get; set; }
    public int IdAgenteModel { get; set; }
}
