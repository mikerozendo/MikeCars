namespace MikeCars.Dto.Repository.Models;

public class RepresentanteModel : Base
{
    public AgenteModel AgenteModel { get; set; }
    public int IdAgenteModel { get; set; }
    public int EmpresaId { get; set; }
    public PessoaJuridicaModel PessoaJuridicaModel { get; set; }
}
