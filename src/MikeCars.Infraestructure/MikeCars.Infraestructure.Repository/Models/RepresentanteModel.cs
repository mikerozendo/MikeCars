namespace MikeCars.Infraestructure.Repository.Models;
public class RepresentanteModel : BaseModel
{
    public int PessoaJuridicaModelId { get; set; }
    public PessoaJuridicaModel PessoaJuridicaModel { get; set; }
    public int PessoaFisicaModelId { get; set; }
    public PessoaFisicaModel PessoaFisicaModel { get; set; }
}
