namespace MikeCars.Infraestructure.Repository.Models;

public class PessoaFisicaModel : AgenteModel
{
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }
}
