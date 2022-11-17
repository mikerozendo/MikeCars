namespace MikeCars.Dto.Repository.Models;

public class RepresentanteModel : Base
{
    public int PessoaJuridicaModelId { get; set; }
    public PessoaJuridicaModel PessoaJuridicaModel { get; set; }
    public int PessoaFisicaModelId { get; set; }
    public PessoaFisicaModel PessoaFisicaModel { get; set; }
}
