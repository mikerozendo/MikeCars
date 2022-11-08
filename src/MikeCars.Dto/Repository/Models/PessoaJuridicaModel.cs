namespace MikeCars.Dto.Repository.Models;

public class PessoaJuridicaModel : Base
{
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public DateTime Abertura { get; set; }
    public RepresentanteModel Representante { get; set; }
    public int IdPessoaRepresentante { get; set; }
    public AgenteModel AgenteModel { get; set; }
    public int IdAgenteModel { get; set; }
}
