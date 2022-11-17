namespace MikeCars.Dto.Repository.Models;

public class RepresentanteModel : PessoaFisicaModel
{
    public int EmpresaId { get; set; }
    public PessoaJuridicaModel PessoaJuridicaModel { get; set; }
}
