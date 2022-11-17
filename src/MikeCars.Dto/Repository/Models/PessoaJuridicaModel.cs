namespace MikeCars.Dto.Repository.Models;

public class PessoaJuridicaModel : AgenteModel
{
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public DateTime Abertura { get; set; }
    public RepresentanteModel RepresentanteModel { get; set; }
    public int IdPessoaRepresentanteModel { get; set; }
}
