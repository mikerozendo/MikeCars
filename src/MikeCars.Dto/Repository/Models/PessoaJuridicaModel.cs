namespace MikeCars.Dto.Repository.Models;

public class PessoaJuridicaModel : Base
{
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public DateTime Abertura { get; set; }
    public RepresentanteModel RepresentanteModel { get; set; }
    public int IdPessoaRepresentanteModel { get; set; }
    public AgenteModel AgenteModel { get; set; }
    public int IdAgenteModel { get; set; }
    public DocumentoModel DocumentoModel { get; set; }
    public int DocumentoModelId { get; set; }
}
